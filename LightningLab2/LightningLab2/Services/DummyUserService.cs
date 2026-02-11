using LightningLab2.Abstractions;
using LightningLab2.Data;
using LightningLab2.Models;

namespace LightningLab2.Services;

public class DummyUserService : IUserService
{
    private readonly LibraryDbContext _dbContext;

    public DummyUserService(LibraryDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public User? GetUser(int id) => _dbContext.Users.FirstOrDefault(u => u.Id == id);

    public IEnumerable<User> GetAllUsers() => _dbContext.Users.ToList();
}
