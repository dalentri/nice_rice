using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using rice_ecommerce.Application.Auth.Commands.Login;

namespace rice_ecommerce.Web.Endpoints;

public class Auth : IEndpointGroup
{
    public static void Map(RouteGroupBuilder groupBuilder)
    {
        groupBuilder.MapPost("/", Login).WithName("LoginCommand");
    }

    [EndpointSummary("Logs in a user")]
    [EndpointDescription("Logs in a user with JWT Authentication using their email and password.")]
    public static async Task<Ok<AuthResponseDto>> Login(
        ISender sender,
        [FromBody] LoginCommand command
    )
    {
        var response = await sender.Send(command);
        return TypedResults.Ok(response);
    }
}
