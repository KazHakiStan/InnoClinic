namespace PhotoService.Domain.Entities;

public class Photo
{
    public Guid Id { get; set; }
    public string Url { get; set; } = null!;
}
