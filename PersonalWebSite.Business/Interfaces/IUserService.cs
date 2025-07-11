using PersonalWebSite.Core.Models;

namespace PersonalWebSite.Business.Interfaces
{
    public interface IUserService
    {
        Task<User?> GetUserByIdAsync(string id);
        Task<User?> GetUserByUsernameAsync(string username);
        Task<User> CreateUserAsync(User user, string password);
        Task<bool> ValidateUserAsync(string username, string password);
    }
} 