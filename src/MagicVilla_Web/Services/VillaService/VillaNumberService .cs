using MagicVilla_Web.Models;
using MagicVilla_Web.Models.Dtos.VillaDtos;
using MagicVilla_Web.Models.Dtos.VillaNumberDtos;
using MagicVilla_Web.Services.IService;
using static MagicVilla_Utility.StaticDetail;

namespace MagicVilla_Web.Services.VillaNumberService
{
    public class VillaNumberService : BaseService, IVillaNumberService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private string _villaUrl;

        public VillaNumberService(IHttpClientFactory httpClient, IConfiguration configuration) : base(httpClient)
        {
            _httpClientFactory = httpClient;
            _villaUrl = configuration.GetValue<string>("ServiceUrls:VillaAPI");
        }

        public Task<T> CreateAsync<T>(VillaNumDto villaNumberDto)
        {
            return SendAsync<T>(new APIRequest()
            {
                APItype = APIType.Post,
                Data = villaNumberDto,
                APIurl = _villaUrl + "/api/villaNumberAPI"
            });
        }

        public Task<T> DeleteAsync<T>(int id)
        {
            return SendAsync<T>(new APIRequest()
            {
                APItype = APIType.Delete,
                APIurl = _villaUrl + "/api/villaNumberAPI/" + id
            });
        }

        public async Task<T> GetAllAsync<T>()
        {
            return await SendAsync<T>(new APIRequest()
            {
                APItype = APIType.Get,
                APIurl = _villaUrl + "/api/villaNumberAPI"
            });
        }

        public Task<T> GetAsync<T>(int id)
        {
            return SendAsync<T>(new APIRequest()
            {
                APItype = APIType.Get,
                APIurl = _villaUrl + "/api/villaNumberAPI/" + id
            });
        }

        public Task<T> UpdateAsync<T>(VillaNumDto villaUpdateDto)
        {
            return SendAsync<T>(new APIRequest()
            {
                APItype = APIType.Put,
                Data = villaUpdateDto,
                APIurl = _villaUrl + "/api/villaNumberAPI"
            });
        }
    }
}
