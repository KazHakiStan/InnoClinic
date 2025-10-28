namespace CategoryService.Domain.Entities;

public class Category
{
    public Guid Id { get; set; }
    public string CategoryName { get; set; } = null!;
    public DateTime TimeSlotSize { get; set; }
}
