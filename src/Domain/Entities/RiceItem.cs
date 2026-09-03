namespace rice_ecommerce.Domain.Entities;

public class RiceItem
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public int Downloads { get; set; } = 0;
    public required string? DownloadLink { get; set; }
    public bool IsActive { get; init; }
    public string CreatedBy { get; init; } = "No Author";
    public DateTimeOffset CreatedDate { get; init; }
}
