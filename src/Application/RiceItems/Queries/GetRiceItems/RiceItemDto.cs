namespace rice_ecommerce.Application.RiceItems.Queries.GetRiceItems;

public record RiceItemDto
{
    public int Id { get; init; }
    public required string Title { get; init; }
    public int Downloads { get; init; } = 0;
    public required string? DownloadLink { get; init; }
}
