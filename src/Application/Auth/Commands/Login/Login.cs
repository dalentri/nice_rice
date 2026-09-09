using System.Security.Authentication;
using rice_ecommerce.Application.Common.Interfaces;

namespace rice_ecommerce.Application.Auth.Commands.Login;

public record LoginCommand(string Email, string Password) : IRequest<AuthResponseDto> { }

public class LoginCommandValidator : AbstractValidator<LoginCommand>
{
    public LoginCommandValidator() { }
}

public class LoginCommandHandler : IRequestHandler<LoginCommand, AuthResponseDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IIdentityService _identityService;
    private readonly ITokenGenerator _tokenGenerator;

    public LoginCommandHandler(
        IApplicationDbContext context,
        IIdentityService identityService,
        ITokenGenerator tokenGenerator
    )
    {
        _context = context;
        _identityService = identityService;
        _tokenGenerator = tokenGenerator;
    }

    public async Task<AuthResponseDto> Handle(
        LoginCommand request,
        CancellationToken cancellationToken
    )
    {
        var (result, userId) = await _identityService.CheckPasswordByEmailAsync(
            request.Email,
            request.Password
        );
        if (!result.Succeeded)
        {
            throw new UnauthorizedAccessException("Invalid credentials.");
        }

        var userName = await _identityService.GetUserNameAsync(userId) ?? request.Email;
        var roles = await _identityService.GetUserRolesAsync(userId);
        var token = _tokenGenerator.GenerateToken(userId, userName, roles);

        return new AuthResponseDto { Token = token, Email = request.Email };
    }
}
