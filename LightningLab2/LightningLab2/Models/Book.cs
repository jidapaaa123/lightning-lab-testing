namespace LightningLab2.Models;

public class Book
{
    public string Id { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public BookStatus Status { get; set; } = BookStatus.Available;
}

public enum BookStatus
{
    Available,
    CheckedOut,
    Lost
}
