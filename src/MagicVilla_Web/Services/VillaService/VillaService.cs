using MagicVilla_Web.Models;
using MagicVilla_Web.Models.Dtos.VillaDtos;
using MagicVilla_Web.Services.IService;
using static MagicVilla_Utility.StaticDetail;

namespace MagicVilla_Web.Services.VillaService
{
    public class VillaService : BaseService, IVillaService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private string _villaUrl;

        public VillaService(IHttpClientFactory httpClient, IConfiguration configuration) : base(httpClient)
        {
            _httpClientFactory = httpClient;
            _villaUrl = configuration.GetValue<string>("ServiceUrls:VillaAPI");
        }

        public Task<T> CreateAsync<T>(VillaCreateDto villaCreateDto)
        {
            return SendAsync<T>(new APIRequest()
            {
                APItype = APIType.Post,
                Data = villaCreateDto,
                APIurl = _villaUrl + "/api/villaAPI"
            });
        }

        public Task<T> DeleteAsync<T>(int id)
        {
            return SendAsync<T>(new APIRequest()
            {
                APItype = APIType.Delete,
                Data = id,
                APIurl = _villaUrl + "/api/villaAPI" + id
            });
        }

        public Task<T> GetAllAsync<T>()
        {
            return SendAsync<T>(new APIRequest()
            {
                APItype = APIType.Get,
                APIurl = _villaUrl + "/api/villaAPI" 
            });
        }

        public Task<T> GetAsync<T>(int id)
        {
            return SendAsync<T>(new APIRequest()
            {
                APItype = APIType.Get,
                APIurl = _villaUrl + "/api/villaAPI"+ id
            });
        }

        public Task<T> UpdateAsync<T>(int id, VillaUpdateDto villaUpdateDto)
        {
            return SendAsync<T>(new APIRequest()
            {
                APItype = APIType.Put,
                Data = villaUpdateDto,
                APIurl = _villaUrl + "/api/villaAPI" + id
            });
        }
    }
}
