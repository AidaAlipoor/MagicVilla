using MagicVilla_Web.Models;
using Newtonsoft.Json;
using System.Text;
using static MagicVilla_Utility.StaticDetail;

namespace MagicVilla_Web.Services.IService
{
    public class BaseService : IBaseService
    {
        public APIResponse ResponseModel { get; set; }

        public IHttpClientFactory HttpClient { get; set; }

        public BaseService(IHttpClientFactory httpClient)
        {
            ResponseModel = new();
            HttpClient = httpClient;
        }

        public async Task<T> SendAsync<T>(APIRequest apiRequest)
        {
            try
            {
                var client = HttpClient.CreateClient("MagicAPI");
                HttpRequestMessage message = new HttpRequestMessage();
                message.Headers.Add("Accept", "application/json");
                message.RequestUri = new Uri(apiRequest.APIurl);

                switch (apiRequest.APItype)
                {
                    case APIType.Get:
                        message.Method = HttpMethod.Get;
                        break;

                    case APIType.Post:
                        message.Method = HttpMethod.Post;
                        break;

                    case APIType.Put:
                        message.Method = HttpMethod.Put;
                        break;

                    case APIType.Delete:
                        message.Method = HttpMethod.Delete;
                        break;
                }

                if (apiRequest.Data != null)
                {
                    message.Content = new StringContent(
                        JsonConvert.SerializeObject(apiRequest.Data),
                        Encoding.UTF8,
                        "application/json");
                }

                HttpResponseMessage apiResponse = null;

                apiResponse = await client.SendAsync(message);

                var apiContent = await apiResponse.Content.ReadAsStringAsync();

                try
                {
                    APIResponse apiResponseJason = JsonConvert
                        .DeserializeObject<APIResponse>(apiContent);

                    if(apiResponseJason.StatusCode == System.Net.HttpStatusCode.BadGateway 
                        || apiResponseJason.StatusCode == System.Net.HttpStatusCode.BadRequest)
                    {
                        apiResponseJason.StatusCode = System.Net.HttpStatusCode.BadRequest;
                        apiResponseJason.IsSuccess = false;

                        var serializesResponse = JsonConvert.SerializeObject(apiResponseJason);
                        var deserializedsResponse = JsonConvert.DeserializeObject<T>(serializesResponse);
                        return deserializedsResponse;
                    }
                }
                catch (Exception)
                {
                    var apiResponseJson = JsonConvert.DeserializeObject<T>(apiContent);
                    return apiResponseJson;
                }
                var response = JsonConvert.DeserializeObject<T>(apiContent);
                return response;
            }

            catch (Exception ex)
            {
                var dto = new APIResponse()
                {
                    ErrorMessage = new List<string> { Convert.ToString(ex.Message) },
                    IsSuccess = true,
                };

                var response = JsonConvert.SerializeObject(dto);
                var apiResponseJson = JsonConvert.DeserializeObject<T>(response);
                return apiResponseJson;
            }
        }
    }
}
