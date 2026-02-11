using LightningLab2.Models;

namespace LightningLab2.Tests;

public static class UserFactory
{
    public static User CreateValidUser()
    {
        return new User
        {
            Id = 1,
            Name = "Valid User",
            Fines = 0m,
            IsBanned = false
        };
    }

    public static User CreateUserWithExcessiveFines(decimal amount)
    {
        return new User
        {
            Id = 2,
            Name = "User With High Fines",
            Fines = amount,
            IsBanned = false
        };
    }

    public static User CreateBannedUser()
    {
        return new User
        {
            Id = 3,
            Name = "Banned User",
            Fines = 0m,
            IsBanned = true
        };
    }
}
