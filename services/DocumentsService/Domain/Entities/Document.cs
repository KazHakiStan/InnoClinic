namespace DocumentsService.Domain.Entities;

public class Document
{
    public Guid Id { get; set; }
    public string Url { get; set; } = null!;
    public Guid ResultId { get; set; }
}
