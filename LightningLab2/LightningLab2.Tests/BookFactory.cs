using LightningLab2.Models;

namespace LightningLab2.Tests;

public static class BookFactory
{
    public static Book CreateAvailableBook()
    {
        return new Book
        {
            Id = "B001",
            Title = "Test Book",
            Status = BookStatus.Available
        };
    }

    public static Book CreateCheckedOutBook()
    {
        return new Book
        {
            Id = "B002",
            Title = "Checked Out Book",
            Status = BookStatus.CheckedOut
        };
    }

    public static Book CreateLostBook()
    {
        return new Book
        {
            Id = "B003",
            Title = "Lost Book",
            Status = BookStatus.Lost
        };
    }
}
