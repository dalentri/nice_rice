namespace rice_ecommerce.Application.Auth.Commands.Login;

public record AuthResponseDto
{
    public required string Token { get; init; }
    public required string Email { get; init; }
}
