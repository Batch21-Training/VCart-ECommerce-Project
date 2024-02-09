using vcart.Core.Entities;
using vcart.Models;

namespace vcart.Repositories.Interfaces
{
    public interface IUserRepository: IRepository<User>
    {
        bool CreateUser(User user, string Role);
        UserModel ValidateUser(string Email, string Password);
    }
}
