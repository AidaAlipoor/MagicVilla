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
            throw new NotImplementedException();
        }

        public Task<LoginResponseViewModel> Login(LoginRequestDto loginRequestDto)
        {
            throw new NotImplementedException();
        }

        public Task<LocalUser> Register(RegistrationRequestDto registrationRequestDto)
        {
            throw new NotImplementedException();
        }
    }
}
