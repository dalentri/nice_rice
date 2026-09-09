using rice_ecommerce.Application.Common.Models;

namespace rice_ecommerce.Application.Common.Interfaces;

public interface IIdentityService
{
    Task<string?> GetUserNameAsync(string userId);

    Task<bool> IsInRoleAsync(string userId, string role);

    Task<bool> AuthorizeAsync(string userId, string policyName);

    Task<(Result Result, string UserId)> CreateUserAsync(string userName, string password);

    Task<Result> DeleteUserAsync(string userId);

    Task<(Result Result, string UserId)> CheckPasswordByEmailAsync(string email, string password);

    Task<IList<string>> GetUserRolesAsync(string userId);
}
