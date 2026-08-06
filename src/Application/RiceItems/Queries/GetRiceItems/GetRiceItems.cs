using rice_ecommerce.Application.Common.Interfaces;

namespace rice_ecommerce.Application.RiceItems.Queries.GetRiceItems;

public record GetRiceItemsQuery : IRequest<RiceItemDto> { }

public class GetRiceItemsQueryValidator : AbstractValidator<GetRiceItemsQuery>
{
    public GetRiceItemsQueryValidator() { }
}

public class GetRiceItemsQueryHandler : IRequestHandler<GetRiceItemsQuery, RiceItemDto>
{
    private readonly IApplicationDbContext _context;

    public GetRiceItemsQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<RiceItemDto> Handle(
        GetRiceItemsQuery request,
        CancellationToken cancellationToken
    )
    {
        throw new NotImplementedException();
    }
}
