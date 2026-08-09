namespace rice_ecommerce.Domain.Entities;

//TODO: Add creator field
public class RiceItem
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public int Downloads { get; set; } = 0;
    public required string? DownloadLink { get; set; }
}
