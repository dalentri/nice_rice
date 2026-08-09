using rice_ecommerce.Application.Common.Interfaces;
using rice_ecommerce.Domain.Entities;

namespace rice_ecommerce.Application.RiceItems.Commands.CreateRiceItem;

public record CreateRiceItemCommand : IRequest<int>
{
    public required string Title { get; init; }
    public int Downloads { get; init; }
    public string? DownloadLink { get; init; }
}

public class CreateRiceItemCommandValidator : AbstractValidator<CreateRiceItemCommand>
{
    public CreateRiceItemCommandValidator() { }
}

public class CreateRiceItemCommandHandler : IRequestHandler<CreateRiceItemCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateRiceItemCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(
        CreateRiceItemCommand request,
        CancellationToken cancellationToken
    )
    {
        RiceItem tempRiceItem = new RiceItem
        {
            Title = request.Title,
            Downloads = request.Downloads,
            DownloadLink = request.DownloadLink,
        };

        await _context.RiceItems.AddAsync(tempRiceItem, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return tempRiceItem.Id;
    }
}
