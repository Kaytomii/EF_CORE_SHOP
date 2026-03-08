using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Domain.Entities;
namespace Shop.App.Managment_Shop;

public class ManageProductAndCategory
{
    private readonly List<Product> Products = new List<Product>();

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

}
