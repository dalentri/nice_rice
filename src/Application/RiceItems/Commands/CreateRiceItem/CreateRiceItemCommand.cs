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
    public CreateRiceItemCommandValidator()
    {
        RuleFor(x => x.Title).NotEmpty().MaximumLength(120).Matches(@"^[a-zA-Z0-9 ]+$");
        RuleFor(x => x.Downloads).GreaterThanOrEqualTo(0);
        RuleFor(x => x.DownloadLink)
            .Must(link => Uri.TryCreate(link, UriKind.Absolute, out _))
            .When(x => !string.IsNullOrEmpty(x.DownloadLink))
            .WithMessage("Enter a valid Link");
    }
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
            DownloadLink = request.DownloadLink,
        };

        await _context.RiceItems.AddAsync(tempRiceItem, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return tempRiceItem.Id;
    }
}
