using LightningLab2.Models;
using Microsoft.EntityFrameworkCore;

namespace LightningLab2.Data;

public class LibraryDbContext : DbContext
{
    public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<Checkout> Checkouts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>().HasData(
            new User { Id = 1, Name = "Alice Johnson", Fines = 5.00m, IsBanned = false },
            new User { Id = 2, Name = "Bob Smith", Fines = 15.00m, IsBanned = false },
            new User { Id = 3, Name = "Charlie Brown", Fines = 0m, IsBanned = true },
            new User { Id = 4, Name = "Diana Prince", Fines = 0m, IsBanned = false },
            new User { Id = 5, Name = "Eve Wilson", Fines = 3.50m, IsBanned = false }
        );

        modelBuilder.Entity<Book>().HasData(
            new Book { Id = "B001", Title = "Clean Code", Status = BookStatus.Available },
            new Book { Id = "B002", Title = "Design Patterns", Status = BookStatus.CheckedOut },
            new Book { Id = "B003", Title = "The Pragmatic Programmer", Status = BookStatus.Available },
            new Book { Id = "B004", Title = "Refactoring", Status = BookStatus.Lost },
            new Book { Id = "B005", Title = "The C# Player's Guide", Status = BookStatus.Available }
        );

        modelBuilder.Entity<Checkout>().HasData(
            new Checkout { Id = 1, UserId = 1, BookId = "B001", CheckoutDate = new DateTime(2024, 12, 18), ReturnDate = null },
            new Checkout { Id = 2, UserId = 4, BookId = "B002", CheckoutDate = new DateTime(2024, 12, 11), ReturnDate = new DateTime(2024, 12, 23) },
            new Checkout { Id = 3, UserId = 5, BookId = "B003", CheckoutDate = new DateTime(2024, 12, 22), ReturnDate = null }
        );
    }
}
