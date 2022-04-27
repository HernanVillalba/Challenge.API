using Azure;
using Azure.Storage.Files.DataLake;
using Azure.Storage.Files.DataLake.Models;
using Challenge.Infrastructure.Configurations;
using Challenge.Infrastructure.Models;
using Microsoft.Extensions.Azure;
using Newtonsoft.Json;
using System.Text;

namespace Challenge.Infrastructure.Storage;

public class DataLakeService<TConfiguration> where TConfiguration : StorageConfiguration
{
    private readonly DataLakeServiceClient serviceClient;

    public DataLakeService(IAzureClientFactory<DataLakeServiceClient> serviceClient)
    {
        this.serviceClient = serviceClient.CreateClient(typeof(TConfiguration).Name);
    }

    public async Task<DataLakeFileSystemClient> CreateFileSystemAsync(string fileSystemName)
    {
        return await serviceClient.CreateFileSystemAsync(fileSystemName);
    }

    public async Task<DataLakeDirectoryClient> CreateDirectoryAsync(string fileSystemName, string path)
    {
        DataLakeFileSystemClient fileSystemClient = serviceClient.GetFileSystemClient(fileSystemName);

        return await fileSystemClient.CreateDirectoryAsync(path);
    }

    public async Task<DataLakeDirectoryClient> RenameDirectoryAsync(DataLakeDirectoryClient directoryClient, string destinationPath)
    {
        return await directoryClient.RenameAsync(destinationPath);
    }

    public async void DeleteDirectoryAsync(DataLakeFileSystemClient fileSystemClient, string directoryName)
    {
        DataLakeDirectoryClient directoryClient = fileSystemClient.GetDirectoryClient(directoryName);

        await directoryClient.DeleteAsync();
    }

    public async Task<Response<PathInfo>> UploadFile<T>(string fileSystemName, string directoryName, string fileName, T data) where T : DataLakeModelBase
    {
        DataLakeFileSystemClient fileSystemClient = serviceClient.GetFileSystemClient(fileSystemName);

        DataLakeDirectoryClient directoryClient = fileSystemClient.GetDirectoryClient(directoryName);

        DataLakeFileClient fileClient = directoryClient.GetFileClient(fileName);

        Response<PathInfo> response = await fileClient.UploadAsync(data.Serialize(), true);

        return response;
    }

    public async Task<T> DownloadFile<T>(string fileSystemName, string directoryName, string fileName)
    {
        DataLakeFileSystemClient fileSystemClient = serviceClient.GetFileSystemClient(fileSystemName);

        DataLakeDirectoryClient directoryClient = fileSystemClient.GetDirectoryClient(directoryName);

        DataLakeFileClient fileClient = directoryClient.GetFileClient(fileName);

        Response<FileDownloadInfo> downloadResponse = await fileClient.ReadAsync();

        using var reader = new StreamReader(downloadResponse.Value.Content, Encoding.UTF8, true, 4096, true);

        string json = await reader.ReadToEndAsync();

        return JsonConvert.DeserializeObject<T>(json);
    }

    public async Task<IEnumerable<PathItem>> ListFilesInDirectory(DataLakeFileSystemClient fileSystemClient, string path)
    {
        IAsyncEnumerator<PathItem> enumerator = fileSystemClient.GetPathsAsync(path).GetAsyncEnumerator();

        List<PathItem> items = new();

        while (await enumerator.MoveNextAsync())
        {
            items.Add(enumerator.Current);
        }

        return items;
    }
}