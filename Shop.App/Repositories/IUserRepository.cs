using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.App.Repositories;

public interface IUserRepository
{
    User Add(User user);
    User? GetById(Guid id);
    List<User> GetAll();
    void Update(User user);
    void Delete(Guid id);
}

