using Challenge.Infrastructure.Models;
using Newtonsoft.Json;
using Challenge.Infrastructure.Utils;

namespace Challenge.Infrastructure.Http;

public abstract class ApiService
{
    private readonly HttpClient httpClient;

    protected ApiService(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

    public async Task<TResponse> Get<TResponse>(string url, IDictionary<string, string> args = null, IDictionary<string, string> headers = null, params JsonConverter[] converters) where TResponse : ApiModelBase
    {
        using HttpRequestMessage requestMessage = HttpHelper.BuildRequest(HttpMethod.Get, url, args, headers);

        using HttpResponseMessage responseMessage = await httpClient.SendAsync(requestMessage);

        responseMessage.EnsureSuccessStatusCode();

        var responseContent = await responseMessage.Content.ReadAsStringAsync();

        var response = JsonConvert.DeserializeObject<TResponse>(responseContent, converters);

        return response;
    }

    public async Task Post(string url, IDictionary<string, string> args = null, IDictionary<string, string> headers = null, ApiModelBase body = null)
    {
        using HttpRequestMessage requestMessage = HttpHelper.BuildRequest(HttpMethod.Post, url, args, headers, body?.Serialize());

        using HttpResponseMessage responseMessage = await httpClient.SendAsync(requestMessage);

        responseMessage.EnsureSuccessStatusCode();

        return;
    }

    public async Task<TResponse> Post<TResponse>(string url, IDictionary<string, string> args = null, IDictionary<string, string> headers = null, ApiModelBase body = null, params JsonConverter[] converters) where TResponse : ApiModelBase
    {
        using HttpRequestMessage requestMessage = HttpHelper.BuildRequest(HttpMethod.Post, url, args, headers, body?.Serialize());

        using HttpResponseMessage responseMessage = await httpClient.SendAsync(requestMessage);

        responseMessage.EnsureSuccessStatusCode();

        var responseContent = await responseMessage.Content.ReadAsStringAsync();

        var response = JsonConvert.DeserializeObject<TResponse>(responseContent, converters);

        return response;
    }

    public async Task Put(string url, IDictionary<string, string> args = null, IDictionary<string, string> headers = null, ApiModelBase body = null)
    {
        using HttpRequestMessage requestMessage = HttpHelper.BuildRequest(HttpMethod.Put, url, args, headers, body?.Serialize());

        using HttpResponseMessage responseMessage = await httpClient.SendAsync(requestMessage);

        responseMessage.EnsureSuccessStatusCode();

        return;
    }

    public async Task<TResponse> Put<TResponse>(string url, IDictionary<string, string> args = null, IDictionary<string, string> headers = null, ApiModelBase body = null, params JsonConverter[] converters) where TResponse : ApiModelBase
    {
        using HttpRequestMessage requestMessage = HttpHelper.BuildRequest(HttpMethod.Put, url, args, headers, body?.Serialize());

        using HttpResponseMessage responseMessage = await httpClient.SendAsync(requestMessage);

        responseMessage.EnsureSuccessStatusCode();

        var responseContent = await responseMessage.Content.ReadAsStringAsync();

        var response = JsonConvert.DeserializeObject<TResponse>(responseContent, converters);

        return response;
    }

    public async Task Delete(string url, IDictionary<string, string> args = null, IDictionary<string, string> headers = null)
    {
        using HttpRequestMessage requestMessage = HttpHelper.BuildRequest(HttpMethod.Delete, url, args, headers);

        using HttpResponseMessage responseMessage = await httpClient.SendAsync(requestMessage);

        responseMessage.EnsureSuccessStatusCode();

        return;
    }
}