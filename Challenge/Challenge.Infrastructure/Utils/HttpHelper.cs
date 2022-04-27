namespace Challenge.Infrastructure.Utils;

public static class HttpHelper
{
    public static string BuildQuery(IDictionary<string, string> args)
    {
        string query = string.Empty;

        args ??= new Dictionary<string, string>();

        foreach (var arg in args)
        {
            if (!string.IsNullOrEmpty(arg.Value))
            {
                query = $"{query}{(string.IsNullOrEmpty(query) ? "?" : "&")}{arg.Key}={arg.Value}";
            }
        }

        return query;
    }

    public static HttpRequestMessage BuildRequest(HttpMethod method, string endpoint, IDictionary<string, string> args = null,
        IDictionary<string, string> headers = null, HttpContent body = null)
    {
        string query = args is null ? string.Empty : BuildQuery(args);

        HttpRequestMessage request = new(method, $"{endpoint}{query}");

        request.Content = body;

        headers ??= new Dictionary<string, string>();

        foreach (var header in headers)
        {
            request.Headers.Add(header.Key, header.Value);
        }

        return request;
    }
}