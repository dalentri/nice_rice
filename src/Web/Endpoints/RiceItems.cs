using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using rice_ecommerce.Application.RiceItems.Commands.CreateRiceItem;
using rice_ecommerce.Application.RiceItems.Queries.GetRiceItems;
using rice_ecommerce.Infrastructure.Identity;

namespace rice_ecommerce.Web.Endpoints;

public class RiceItems : IEndpointGroup
{
    public static void Map(RouteGroupBuilder groupBuilder)
    {
        groupBuilder.MapGet("/", GetRiceItems);
        groupBuilder.MapPost("/", CreateRiceItem).RequireAuthorization();
        //TODO: Implement delete item
        // groupBuilder.MapDelete("/", DeleteRiceItem);
    }

    [EndpointSummary("Get all rices")]
    [EndpointDescription("Returns all linux rice objects from the database.")]
    public static async Task<Ok<List<RiceItemDto>>> GetRiceItems(
        ISender sender,
        [AsParameters] GetRiceItemsQuery query
    )
    {
        var items = await sender.Send(query);
        return TypedResults.Ok(items);
    }

    [EndpointSummary("Create a rice")]
    [EndpointDescription("Creates a linux rice object and pushes to the database.")]
    public static async Task<Created<int>> CreateRiceItem(
        ISender sender,
        [FromBody] CreateRiceItemCommand command
    )
    {
        var id = await sender.Send(command);
        return TypedResults.Created($"/api/rice-items/{id}", id);
    }
}
