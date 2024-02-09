using vcart.Core.Entities;
using vcart.Models;

namespace vcart.Services.Interfaces
{
    public interface IAuthService
    {
        bool CreateUser(User user, string Role);
        UserModel ValidateUser(string Email, string Password);
    }
}
