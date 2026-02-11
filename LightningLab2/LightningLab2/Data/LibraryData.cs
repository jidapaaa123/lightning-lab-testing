using LightningLab2.Models;

namespace LightningLab2.Data;

public static class LibraryData
{
    public static List<User> GetUsers() => new()
    {
        new User { Id = 1, Name = "Alice Johnson", Fines = 5.00m, IsBanned = false },
        new User { Id = 2, Name = "Bob Smith", Fines = 15.00m, IsBanned = false },
        new User { Id = 3, Name = "Charlie Brown", Fines = 0m, IsBanned = true },
        new User { Id = 4, Name = "Diana Prince", Fines = 0m, IsBanned = false }
    };

    public static List<Book> GetBooks() => new()
    {
        new Book { Id = "B001", Title = "Clean Code" },
        new Book { Id = "B002", Title = "Design Patterns" },
        new Book { Id = "B003", Title = "The Pragmatic Programmer" },
        new Book { Id = "B004", Title = "Refactoring" }
    };

    public static List<string> GetAvailableBookIds() => new()
    {
        "B001", "B003", "B004"
    };
}
