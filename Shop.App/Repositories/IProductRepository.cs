using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.App.Repositories;

public interface IProductRepository
{
    Product Add(Product product);
    List<Product> GetAll();
    Product? GetById(Guid id);
    void Update(Product product);
    void Delete(Guid id);
}

