using vcart.Core;
using vcart.Core.Entities;
using vcart.Models;
using vcart.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace vcart.Repositories.Implementations
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        AppDbContext dbContext
        {
            get { return _db as AppDbContext; }
        }
        public UserRepository(AppDbContext db) : base(db)
        {
            // dbContext = db;
        }

        public bool CreateUser(User user, string Role)
        {
            try
            {
                Role role = dbContext.Roles.Where(r => r.Name == Role).FirstOrDefault();
                if (role != null)
                {
                    user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password); //hashing
                    user.Roles.Add(role);
                    dbContext.Users.Add(user);
                    dbContext.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {

            }
            return false;
        }

        public UserModel ValidateUser(string Email, string Password)
        {
            User user = dbContext.Users.Include(u => u.Roles).Where(u => u.Email == Email).FirstOrDefault();
            if (user != null)
            {
                bool isVerified = BCrypt.Net.BCrypt.Verify(Password, user.Password);
                if (isVerified)
                {
                    UserModel model = new UserModel
                    {
                        Id = user.Id,
                        Name = user.Name,
                        Email = user.Email,
                        PhoneNumber = user.PhoneNumber,
                        Roles = user.Roles.Select(r => r.Name).ToArray()
                    };
                    return model;
                }
            }
            return null;
        }
    }
}
