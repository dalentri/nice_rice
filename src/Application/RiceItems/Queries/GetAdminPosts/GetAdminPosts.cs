using rice_ecommerce.Application.Common.Interfaces;

namespace rice_ecommerce.Application.RiceItems.Queries.GetAdminPosts;

public record GetAdminPostsQuery : IRequest<List<AdminRiceItemDto>> { }

public class GetAdminPostsQueryValidator : AbstractValidator<GetAdminPostsQuery>
{
    public GetAdminPostsQueryValidator() { }
}

public class GetAdminPostsQueryHandler : IRequestHandler<GetAdminPostsQuery, List<AdminRiceItemDto>>
{
    private readonly IApplicationDbContext _context;

    public GetAdminPostsQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<AdminRiceItemDto>> Handle(
        GetAdminPostsQuery request,
        CancellationToken cancellationToken
    )
    {
        return await _context
            .RiceItems.Select(item => new AdminRiceItemDto
            {
                Id = item.Id,
                Title = item.Title,
                Downloads = item.Downloads,
                DownloadLink = item.DownloadLink,
                IsActive = item.IsActive,
                CreatedBy = item.CreatedBy,
                CreatedDate = item.CreatedDate,
            })
            .ToListAsync(cancellationToken);
    }
}
