using AutoMapper;
using Business.Dtos.LocalUserDto;
using Business.Repositories.ParentRepository;
using Business.ViewModels;
using DataAccess;
using DataAccess.Entities;

namespace Business.Repositories.LocalUserRepository
{
    internal class UserRepository : Repository<LocalUser>, IUserRepository
    {
        private readonly IMapper _mapper;

        public UserRepository(ApplicationDbContext dbContext, IMapper mapper)
            : base(dbContext) => _mapper = mapper;


        public bool IsUniqueUser(string username)
        {
            var user = GetAllAsync(u => u.UserName == username);

            if(user is not null)
                return true;
            return false;
        }

        public Task<LoginResponseViewModel> Login(LoginRequestDto loginRequestDto)
        {
            throw new NotImplementedException();
        }

        public async Task<LocalUser> Register(RegistrationRequestDto registrationRequestDto)
        {
            var newUser = new LocalUser()
            {
                Name = registrationRequestDto.Name,
                password = registrationRequestDto.Password,
                UserName = registrationRequestDto.Password,
                Role = registrationRequestDto.Role,
            };

            Insert(newUser);

            await SaveChangesAsync();

            newUser.password = "";

            return newUser; 
        }
        public async Task DeleteAsync(int id)
        {
            await CheckIdExist(id);

            var user = await GetAsync(id);

            Delete(user);
        }

        private async Task CheckIdExist(int id)
        {
            var user = await GetAsync(id);

            if(user is null)
                throw new Exception("id does not exist");
        }
    }
}
