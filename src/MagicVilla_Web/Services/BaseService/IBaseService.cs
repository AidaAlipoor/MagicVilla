using MagicVilla_Web.Models;
namespace MagicVilla_Web.Services.IService
{
    public interface IBaseService
    {
        APIResponse ResponseModel { get; set; }
        Task<T> SendAsync<T>(APIRequest apiRequest); 
    }
}
