using rice_ecommerce.Application.Common.Interfaces;
using rice_ecommerce.Application.RiceItems.Queries.GetRiceItems;

namespace rice_ecommerce.Application.RiceItems.Queries.GetRiceItems;

public record GetRiceItemsQuery : IRequest<List<RiceItemDto>> { }

public class GetRiceItemsQueryValidator : AbstractValidator<GetRiceItemsQuery>
{
    public GetRiceItemsQueryValidator() { }
}

public class GetRiceItemsQueryHandler : IRequestHandler<GetRiceItemsQuery, List<RiceItemDto>>
{
    private readonly IApplicationDbContext _context;

    public GetRiceItemsQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<RiceItemDto>> Handle(
        GetRiceItemsQuery request,
        CancellationToken cancellationToken
    )
    {
        return await _context
            .RiceItems.Select(item => new RiceItemDto
            {
                Id = item.Id,
                Title = item.Title,
                Downloads = item.Downloads,
                DownloadLink = item.DownloadLink,
            })
            .ToListAsync(cancellationToken);
    }
}
