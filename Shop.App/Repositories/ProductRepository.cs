using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Shop.App.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly List<Product> _products = new();

    public Product Add(Product product)
    {
        _products.Add(product);
        return product;
    }

    public List<Product> GetAll()
    {
        return _products;
    }

    public Product? GetById(Guid id)
    {
        return _products.FirstOrDefault(p => p.Id == id);
    }

    public void Update(Product product)
    {
        var existing = GetById(product.Id);
        if (existing == null) return;

        existing.Name = product.Name;
        existing.Price = product.Price;
        existing.StockQuantity = product.StockQuantity;
        existing.CreatedAt = product.CreatedAt;
        existing.Categories = product.Categories;
    }

    public void Delete(Guid id)
    {
        var product = GetById(id);
        if (product != null)
            _products.Remove(product);
    }
}
