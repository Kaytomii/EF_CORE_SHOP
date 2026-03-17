using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Shop.App.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly List<Order> _orders = new();

    public Order Add(Order order)
    {
        order.Id = _orders.Count + 1;
        _orders.Add(order);
        return order;
    }

    public Order? GetById(int id)
    {
        return _orders.FirstOrDefault(o => o.Id == id);
    }

    public List<Order> GetByUserId(Guid userId)
    {
        return _orders.Where(o => o.UserId == userId).ToList();
    }

    public void Delete(int id)
    {
        var order = GetById(id);
        if (order != null)
            _orders.Remove(order);
    }
}

