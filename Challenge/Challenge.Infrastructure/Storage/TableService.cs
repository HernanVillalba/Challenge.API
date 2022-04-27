using Azure;
using Azure.Data.Tables;
using Challenge.Infrastructure.Configurations;
using Challenge.Infrastructure.Models;
using Microsoft.Extensions.Azure;
using System.Linq.Expressions;

namespace Challenges.Infrastructure.Storage;

public abstract class TableService<TConfiguration> where TConfiguration : StorageConfiguration
{
    private readonly TableServiceClient serviceClient;

    protected TableService(IAzureClientFactory<TableServiceClient> clientFactory)
    {
        serviceClient = clientFactory.CreateClient(typeof(TConfiguration).Name);
    }

    public async Task<Response<T>> GetEntityAsync<T>(string tableName, string partitionKey, string rowKey) where T : TableModelBase, new()
    {
        TableClient tableClient = serviceClient.GetTableClient(tableName);

        Response<T> response = await tableClient.GetEntityAsync<T>(partitionKey, rowKey);

        return response;
    }

    public AsyncPageable<T> QueryAsync<T>(string tableName, Expression<Func<T, bool>> queryExpression) where T : TableModelBase, new()
    {
        TableClient tableClient = serviceClient.GetTableClient(tableName);

        AsyncPageable<T> queryResult = tableClient.QueryAsync(queryExpression);

        return queryResult;
    }

    public async Task<Response> AddEntityAsync<T>(string tableName, T entity) where T : TableModelBase, new()
    {
        TableClient tableClient = serviceClient.GetTableClient(tableName);

        await tableClient.CreateIfNotExistsAsync();

        Response response = await tableClient.AddEntityAsync(entity);

        return response;
    }

    public async Task<Response> UpdateEntityAsync<T>(string tableName, T entity, TableUpdateMode mode = TableUpdateMode.Merge) where T : TableModelBase, new()
    {
        TableClient tableClient = serviceClient.GetTableClient(tableName);

        await tableClient.CreateIfNotExistsAsync();

        Response response = await tableClient.UpdateEntityAsync(entity, ETag.All, mode);

        return response;
    }

    public async Task<Response> UpsertEntityAsync<T>(string tableName, T entity, TableUpdateMode mode = TableUpdateMode.Merge) where T : TableModelBase, new()
    {
        TableClient tableClient = serviceClient.GetTableClient(tableName);

        await tableClient.CreateIfNotExistsAsync();

        Response response = await tableClient.UpsertEntityAsync(entity, mode);

        return response;
    }

    public async Task<Response> DeleteEntityAsync(string tableName, string partitionKey, string rowkey)
    {
        TableClient tableClient = serviceClient.GetTableClient(tableName);

        Response response = await tableClient.DeleteEntityAsync(partitionKey, rowkey);

        return response;
    }

    public async Task<Response<IReadOnlyList<Response>>> BatchOperation<T>(string tableName, TableTransactionActionType typeOperation, IEnumerable<T> entities) where T : TableModelBase, new()
    {
        TableClient tableClient = serviceClient.GetTableClient(tableName);

        await tableClient.CreateIfNotExistsAsync();

        Response<IReadOnlyList<Response>> response = await tableClient.SubmitTransactionAsync(entities.Select(t => new TableTransactionAction(typeOperation, t)));

        return response;
    }
}