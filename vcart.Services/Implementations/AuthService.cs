using vcart.Core.Entities;
using vcart.Models;
using vcart.Repositories.Interfaces;
using vcart.Services.Interfaces;
using Microsoft.Extensions.Configuration;

namespace vcart.Services.Implementations
{
    public class AuthService : IAuthService
    {
        IUserRepository _userRepo;
        IConfiguration _config;
        public AuthService(IUserRepository userRepo, IConfiguration config)
        {
            _userRepo = userRepo;
            _config = config;
        }

        public bool CreateUser(User user, string Role)
        {
            return _userRepo.CreateUser(user, Role);
        }

        public UserModel ValidateUser(string Email, string Password)
        {
            return _userRepo.ValidateUser(Email, Password);
        }
    }
}
