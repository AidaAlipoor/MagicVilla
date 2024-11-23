using Business.Dtos.LocalUserDto;
using Business.ViewModels;
using DataAccess.Entities;

namespace Business.Repositories.LocalUserRepository
{
    public interface IUserRepository
    {
        bool IsUniqueUser(string username);
        Task<LoginResponseViewModel> Login(LoginRequestDto loginRequestDto);
        Task<LocalUser> Register(RegistrationRequestDto registrationRequestDto);
        Task DeleteAsync(int id);   
    }
}
