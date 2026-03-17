using Shop.App.Repositories;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.App.Services;

public class OrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly IProductRepository _productRepository;
    private readonly IUserRepository _userRepository;

    public OrderService(
        IOrderRepository orderRepository,
        IProductRepository productRepository,
        IUserRepository userRepository)
    {
        _orderRepository = orderRepository;
        _productRepository = productRepository;
        _userRepository = userRepository;
    }

    public Order CreateOrder(Guid userId, List<(Guid productId, int quantity)> items)
    {
        var user = _userRepository.GetById(userId);
        if (user == null)
            throw new Exception("User not found");

        var order = new Order
        {
            UserId = userId,
            OrderDate = DateTime.UtcNow,
            Status = "Created",
            TotalAmount = 0
        };

        foreach (var item in items)
        {
            var product = _productRepository.GetById(item.productId);
            if (product == null)
                throw new Exception($"Product {item.productId} not found");

            if (product.StockQuantity < item.quantity)
                throw new Exception($"Not enough stock for product {product.Name}");

            var orderItem = new OrderItem
            {
                ProductId = product.Id,
                Quantity = item.quantity,
                Price = product.Price
            };

            order.Items.Add(orderItem);

            order.TotalAmount += product.Price * item.quantity;

            product.StockQuantity -= item.quantity;
            _productRepository.Update(product);
        }

        return _orderRepository.Add(order);
    }

    public Order? GetOrderById(int id)
    {
        return _orderRepository.GetById(id);
    }

    public List<Order> GetOrdersByUser(Guid userId)
    {
        return _orderRepository.GetByUserId(userId);
    }

    public bool DeleteOrder(int id)
    {
        var order = _orderRepository.GetById(id);
        if (order == null) return false;

        _orderRepository.Delete(id);
        return true;
    }
}
