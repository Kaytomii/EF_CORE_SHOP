using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Shop.App.Repositories;

public class UserRepository : IUserRepository
{
    private readonly List<User> _users = new();

    public User Add(User user)
    {
        _users.Add(user);
        return user;
    }

    public User? GetById(Guid id)
    {
        return _users.FirstOrDefault(u => u.Id == id);
    }

    public List<User> GetAll()
    {
        return _users;
    }

    public void Update(User user)
    {
        var existing = GetById(user.Id);
        if (existing == null) return;

        existing.Name = user.Name;
        existing.SurName = user.SurName;
        existing.Email = user.Email;
        existing.HashPassword = user.HashPassword;
        existing.Role = user.Role;
    }

    public void Delete(Guid id)
    {
        var user = GetById(id);
        if (user != null)
            _users.Remove(user);
    }
}

