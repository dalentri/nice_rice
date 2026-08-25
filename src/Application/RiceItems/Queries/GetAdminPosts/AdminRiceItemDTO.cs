namespace rice_ecommerce.Application.RiceItems.Queries.GetAdminPosts;

public record AdminRiceItemDto
{
    public int Id { get; init; }
    public required string Title { get; init; }
    public int Downloads { get; init; } = 0;
    public required string? DownloadLink { get; init; }
    public bool IsActive { get; init; }
    public string CreatedBy { get; init; } = "No Author";
    public DateTime CreatedDate { get; init; }
}
