using Shop.App.Repositories;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.App.Services;

public class ProductService
{
    private readonly IProductRepository _repository;

    public ProductService(IProductRepository repository)
    {
        _repository = repository;
    }

    public Product AddProduct(string name, string? description, decimal price, int quantity)
    {
        var product = new Product
        {
            Id = Guid.NewGuid(),
            Name = name,
            Price = price,
            StockQuantity = quantity,
            CreatedAt = DateTime.UtcNow
        };

        return _repository.Add(product);
    }

    public List<Product> GetAllProducts()
    {
        return _repository.GetAll();
    }

    public Product? GetProductById(Guid id)
    {
        return _repository.GetById(id);
    }

    public bool UpdateProduct(Guid id, string name, string? description, decimal price, int quantity)
    {
        var product = _repository.GetById(id);
        if (product == null) return false;

        product.Name = name;
        product.Price = price;
        product.StockQuantity = quantity;

        _repository.Update(product);
        return true;
    }

    public bool DeleteProduct(Guid id)
    {
        var product = _repository.GetById(id);
        if (product == null) return false;

        _repository.Delete(id);
        return true;
    }
}

