using Azure;
using Azure.Storage.Queues;
using Azure.Storage.Queues.Models;
using Challenge.Infrastructure.Configurations;
using Challenge.Infrastructure.Models;
using Microsoft.Extensions.Azure;

namespace Challenge.Infrastructure.Storage;

public abstract class QueueService<TConfiguration> where TConfiguration : StorageConfiguration
{
    private readonly QueueServiceClient serviceClient;

    protected QueueService(IAzureClientFactory<QueueServiceClient> clientFactory)
    {
        serviceClient = clientFactory.CreateClient(typeof(TConfiguration).Name);
    }

    public async Task<Response> CreateIfNotExists(string queue)
    {
        QueueClient queueClient = serviceClient.GetQueueClient(queue);

        Response res = await queueClient.CreateIfNotExistsAsync();

        return res;
    }

    public async Task<Response<SendReceipt>> Enqueue(string queue, QueueModelBase data)
    {
        QueueClient queueClient = serviceClient.GetQueueClient(queue);

        Response<SendReceipt> res = await queueClient.SendMessageAsync(data.ToJson());

        return res;
    }

    public async Task<QueueMessage> GetMessages(string queueName)
    {
        QueueClient queueClient = serviceClient.GetQueueClient(queueName);

        Response<QueueMessage> queueMessage = await queueClient.ReceiveMessageAsync();

        return queueMessage;
    }

    public async Task<Response> DeleteMessage(string queueName, QueueMessage queueMessage)
    {
        QueueClient queueClient = serviceClient.GetQueueClient(queueName);

        Response response = await queueClient.DeleteMessageAsync(queueMessage.MessageId, queueMessage.PopReceipt);

        return response;
    }
}