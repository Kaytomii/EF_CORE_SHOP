using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.App.Repositories;

public interface IOrderRepository
{
    Order Add(Order order);
    Order? GetById(int id);
    List<Order> GetByUserId(Guid userId);
    void Delete(int id);
}
