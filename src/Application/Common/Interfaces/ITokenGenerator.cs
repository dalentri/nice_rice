namespace rice_ecommerce.Application.Common.Interfaces;

public interface ITokenGenerator
{
    string GenerateToken(string userId, string userName, IEnumerable<string> roles);
}
