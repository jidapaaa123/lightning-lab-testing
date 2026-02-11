using LightningLab2.Models;

namespace LightningLab2.Abstractions;

public interface IBookService
{
    Book? GetBook(string bookId);
    bool IsAvailable(string bookId);
    IEnumerable<Book> GetAllBooks();
}
