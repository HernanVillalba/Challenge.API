using Azure;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Challenge.Infrastructure.Configurations;
using Challenge.Infrastructure.Models;
using Microsoft.Extensions.Azure;
using Newtonsoft.Json;
using System.Text;

namespace Challenges.Infrastructure.Storage;

public abstract class BlobService<TConfiguration> where TConfiguration : StorageConfiguration
{
    private readonly BlobServiceClient serviceClient;

    public BlobService(IAzureClientFactory<BlobServiceClient> serviceClient)
    {
        this.serviceClient = serviceClient.CreateClient(typeof(TConfiguration).Name);
    }

    public async Task<Response<BlobContainerInfo>> CreateIfNotExistsAsync(string containerName)
    {
        BlobContainerClient containerClient = serviceClient.GetBlobContainerClient(containerName);

        return await containerClient.CreateIfNotExistsAsync();
    }

    public async Task<bool> ExistsAsync(string containerName, string blobName)
    {
        BlobContainerClient containerClient = serviceClient.GetBlobContainerClient(containerName);

        BlobClient blobClient = containerClient.GetBlobClient(blobName);

        return await blobClient.ExistsAsync();
    }

    public async Task<TResponse> GetAsync<TResponse>(string containerName, string blobName)
    {
        BlobContainerClient containerClient = serviceClient.GetBlobContainerClient(containerName);

        BlobClient blobClient = containerClient.GetBlobClient(blobName);

        Response<BlobDownloadStreamingResult> stream = await blobClient.DownloadStreamingAsync();

        using var reader = new StreamReader(stream.Value.Content, Encoding.UTF8, true, 4096, true);

        string json = await reader.ReadToEndAsync();

        return JsonConvert.DeserializeObject<TResponse>(json);
    }

    public async Task<Response<BlobContentInfo>> UploadAsync<T>(string containerName, string blobName, T data) where T : BlobModelBase
    {
        BlobContainerClient containerClient = serviceClient.GetBlobContainerClient(containerName);

        BlobClient blobClient = containerClient.GetBlobClient(blobName);

        Response<BlobContentInfo> response = await blobClient.UploadAsync(data.Serialize(), true);

        return response;
    }

    public async Task<Response> DeleteAsync(string containerName, string blobName)
    {
        BlobContainerClient containerClient = serviceClient.GetBlobContainerClient(containerName);

        BlobClient blobClient = containerClient.GetBlobClient(blobName);

        Response response = await blobClient.DeleteAsync();

        return response;
    }

    public AsyncPageable<BlobItem> GetBlobsAsync(string container, string prefix = null)
    {
        BlobContainerClient containerClient = serviceClient.GetBlobContainerClient(container);

        return containerClient.GetBlobsAsync(prefix: prefix);
    }
}