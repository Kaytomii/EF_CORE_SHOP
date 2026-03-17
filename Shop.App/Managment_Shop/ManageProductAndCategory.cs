using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Domain.Entities;
using Shop.App.Data;
namespace Shop.App.Managment_Shop;

public class ManageProductAndCategory
{
    private readonly List<Product> Products = new List<Product>();
    private readonly List<Category> Categories = new List<Category>();
    private readonly ShopDbContext _context;

    public ManageProductAndCategory(ShopDbContext context)
    {
        _context = context;
    }


    public Product CreateProduct(string name, decimal price, int stockQuantity)
    {
        var product = new Product
        {
            Id = Guid.NewGuid(),
            Name = name,
            Price = price,
            StockQuantity = stockQuantity,
            CreatedAt = DateTime.UtcNow
        };

        Products.Add(product);
        return product;
    }

    public bool UpdateProductName(Guid id, string newName)
    {
        var product = Products.FirstOrDefault(p => p.Id == id);
        if (product == null) return false;

        product.Name = newName;
        return true;
    }

    public bool UpdateProductQuantity(Guid id, int newQuantity)
    {
        var product = Products.FirstOrDefault(p => p.Id == id);
        if (product == null) return false;

        product.StockQuantity = newQuantity;
        return true;
    }

    public bool DeleteProduct(Guid id)
    {
        var product = Products.FirstOrDefault(p => p.Id == id);
        if (product == null) return false;

        Products.Remove(product);
        return true;
    }

    public List<Product> GetOutOfStockProducts()
    {
        return (List<Product>)Products.Where(p => p.StockQuantity <= 0);
    }

    public List<Product> GetTop3MostExpensiveProducts()
    {
        return (List<Product>)Products
            .OrderByDescending(p => p.Price)
            .Take(3);
    }

    public List<Category> GetCategoriesByProduct(Guid productId)
    {
        var product = Products.FirstOrDefault(p => p.Id == productId);
        if (product == null) return new List<Category>();

        return product.Categories!
        .Select(cp => Categories.FirstOrDefault(c => c.Id == cp.CategoryId))
        .Where(c => c != null)!
        .ToList()!;

    }

    public List<Product> GetProductsByCategory(Guid categoryId)
    {
        return Products
            .Where(p => p.Categories != null &&
                        p.Categories.Any(cp => cp.CategoryId == categoryId))
            .ToList();
    }

    public Order CreateOrder(Guid userId, List<(Guid productId, int quantity)> items)
    {
        using (var transaction = _context.Database.BeginTransaction())
        {
            try
            {
                var user = _context.Users.FirstOrDefault(u => u.Id == userId);
                if (user == null)
                    throw new Exception("User not found");

                var order = new Order
                {
                    UserId = userId,
                    OrderDate = DateTime.UtcNow,
                    Status = "Created",
                    TotalAmount = 0
                };

                _context.Orders.Add(order);
                _context.SaveChanges();

                foreach (var item in items)
                {
                    var product = _context.Products.FirstOrDefault(p => p.Id == item.productId);
                    if (product == null)
                        throw new Exception($"Product {item.productId} not found");

                    if (product.StockQuantity < item.quantity)
                        throw new Exception($"Not enough stock for product {product.Name}");

                    var orderItem = new OrderItem
                    {
                        OrderId = order.Id,
                        ProductId = product.Id,
                        Quantity = item.quantity,
                        Price = product.Price
                    };

                    _context.OrderItems.Add(orderItem);

                    product.StockQuantity -= item.quantity;
                    _context.Products.Update(product);

                    order.TotalAmount += product.Price * item.quantity;
                }

                _context.SaveChanges();
                transaction.Commit();

                return order;
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }
    }

}
