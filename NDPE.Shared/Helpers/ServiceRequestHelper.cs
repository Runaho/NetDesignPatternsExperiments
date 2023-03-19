using System;
using System.Net;
using System.Text;
using System.Text.Json;

namespace NDPE.Shared.Helpers;

public class ServiceRequestHelper<T>
{
    public record ResponseMessage(T? Value, HttpStatusCode Code);
    JsonSerializerOptions jsonSerializerOptions;
    public ServiceRequestHelper(HttpClient httpClient)
    {
        _httpClient = httpClient;
        jsonSerializerOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
        };
    }

    public HttpClient _httpClient { get; }

    public async Task<ResponseMessage> GetAsync(string path)
    {
        var request = await _httpClient.GetAsync(path, HttpCompletionOption.ResponseHeadersRead);
        var result = await JsonSerializer.DeserializeAsync<T>
             (await request.Content.ReadAsStreamAsync(), options: jsonSerializerOptions);

        return new ResponseMessage(result, request.StatusCode);
    }

    public async Task<ResponseMessage> DeleteAsync(string path, string id)
    {
        var request = await _httpClient.DeleteAsync($"{path}/{id}");
        var result = await JsonSerializer.DeserializeAsync<T>
              (await request.Content.ReadAsStreamAsync(), options: jsonSerializerOptions);

        return new ResponseMessage(result, request.StatusCode);

    }

    public async Task<ResponseMessage> SendAsync(string path, object model, RequestTypes requestTypes)
    {
        var json = new StringContent(JsonSerializer.Serialize(model), encoding: Encoding.UTF8, "application/json");
        HttpResponseMessage response = null;

        switch (requestTypes)
        {
            case RequestTypes.Post:
                response = await _httpClient.PostAsync(path, json);
                break;
            case RequestTypes.Put:
                response = await _httpClient.PutAsync(path, json);
                break;
            default:
                break;
        }
        var result = await JsonSerializer.DeserializeAsync<T>(await response.Content.ReadAsStreamAsync(), options: jsonSerializerOptions);


        return new ResponseMessage(result, response.StatusCode);
    }
}

public enum RequestTypes
{
    Put,
    Post
}