using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using rice_ecommerce.Application.RiceItems.Queries.GetAdminPosts;
using rice_ecommerce.Application.RiceItems.Queries.GetRiceItems;
using rice_ecommerce.Infrastructure.Identity;

namespace rice_ecommerce.Web.Endpoints;

public class Admin : IEndpointGroup
{
    public static void Map(RouteGroupBuilder groupBuilder)
    {
        groupBuilder.MapGet("/", GetAdminPostsQuery).WithName("GetAdminPosts");
    }

    [EndpointSummary("Get all full-detailed rices")]
    [EndpointDescription(
        "Returns all linux rice items with extensive admin information from the database."
    )]
    public static async Task<Ok<List<AdminRiceItemDto>>> GetAdminPostsQuery(
        ISender sender,
        [AsParameters] GetAdminPostsQuery query
    )
    {
        var items = await sender.Send(query);
        return TypedResults.Ok(items);
    }
}
