using MessangerBackend.Core.Interfaces;
using MessangerBackend.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace MessangerBackend.Core.Services;

public class UserService : IUserService
{
    private readonly IRepository _repository;

    public UserService(IRepository repository)
    {
        _repository = repository;
    }

    public Task<User> Login(string nickname, string password)
    {
        if (nickname == null || string.IsNullOrEmpty(nickname.Trim()) || 
            password == null || string.IsNullOrEmpty(password.Trim()))
        {
            throw new ArgumentNullException();
        }
        return _repository.GetAll<User>()
            .SingleAsync(x => x.Nickname == nickname && x.Password == password);
    }

    public Task<User> Register(string nickname, string password)
    {
        throw new NotImplementedException();
    }

    public Task<User> GetUserById(int id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<User> GetUsers(int page, int size)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<User> SearchUsers(string nickname)
    {
        throw new NotImplementedException();
    }
}