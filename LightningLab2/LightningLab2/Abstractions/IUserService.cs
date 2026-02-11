using LightningLab2.Models;

namespace LightningLab2.Abstractions;

public interface IUserService
{
    User? GetUser(int id);
    IEnumerable<User> GetAllUsers();
}
