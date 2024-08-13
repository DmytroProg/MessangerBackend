using MessangerBackend.Core.Interfaces;
using MessangerBackend.Core.Models;
using MessangerBackend.Core.Services;
using MessangerBackend.Storage;
using Microsoft.EntityFrameworkCore;

namespace MessangerBackend.Tests;

public class UserServiceTests
{
    [Fact]
    public async Task UserService_Login_CorrectInput()
    {
        // AAA Assign, Act, Assert
        var userService = CreateUserService();
        var expectedUser = new User()
        {
            Nickname = "TestUser",
            Password = "1111",
        };

        var user = await userService.Login("TestUser", "1111");
        
        Assert.Equal(expectedUser, user, new UserComparer());
    }

    [Theory]
    [InlineData("")]
    [InlineData("     ")]
    [InlineData(null)]
    public async Task UserService_Login_ThrowsExceptionWhenEmptyField(string data)
    {
        // Assign
        var service = CreateUserService();
        
        // Act
        var exceptionNicknameHandler = async () =>
        {
            await service.Login(data, "1234");
        };
        var exceptionPasswordHandler = async () =>
        {
            await service.Login("nick", data);
        };
        
        // Assert
        await Assert.ThrowsAsync<ArgumentNullException>(exceptionNicknameHandler);
        await Assert.ThrowsAsync<ArgumentNullException>(exceptionPasswordHandler);
    }

    private IUserService CreateUserService()
    {
        var options = new DbContextOptionsBuilder<MessangerContext>()
            .UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MessangerDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False")
            .Options;
        var context = new MessangerContext(options);
        var repository = new Repository(context);
        return new UserService(repository);
    }
}

class UserComparer : IEqualityComparer<User>
{
    public bool Equals(User x, User y)
    {
        if (ReferenceEquals(x, y)) return true;
        if (ReferenceEquals(x, null)) return false;
        if (ReferenceEquals(y, null)) return false;
        if (x.GetType() != y.GetType()) return false;
        return x.Nickname == y.Nickname && x.Password == y.Password;
    }

    public int GetHashCode(User obj)
    {
        return HashCode.Combine(obj.Nickname, obj.Password);
    }
}