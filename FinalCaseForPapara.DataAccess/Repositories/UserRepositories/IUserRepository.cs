using FinalCaseForPapara.Entity.Entities;
using Microsoft.AspNetCore.Identity;

namespace FinalCaseForPapara.DataAccess.Repositories.UserRepositories
{
    public interface IUserRepository
    {
        Task<User> FindByEmailAsync(string email);
        Task<bool> CheckPasswordAsync(User user, string password);
        Task<IdentityResult> CreateAsync(User user, string password);
        Task<IdentityResult> AddToRoleAsync(User user, string role);
    }
}
