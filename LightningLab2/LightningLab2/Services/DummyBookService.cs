using LightningLab2.Abstractions;
using LightningLab2.Data;
using LightningLab2.Models;
using System.Linq;

namespace LightningLab2.Services;

public class DummyBookService : IBookService
{
    private readonly LibraryDbContext _dbContext;

    public DummyBookService(LibraryDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Book? GetBook(string bookId) => _dbContext.Books.FirstOrDefault(b => b.Id == bookId);

    public bool IsAvailable(string bookId) => _dbContext.Books.FirstOrDefault(b => b.Id == bookId)?.Status == BookStatus.Available;

    public IEnumerable<Book> GetAllBooks() => _dbContext.Books.ToList();
}

