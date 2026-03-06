using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Entities;

public class CategoryProduct
{
    public Guid? CategoryId { get; set; }
    public Category? Category { get; set; }
    public Guid? ProductId { get; set; }
    public Product? Product { get; set; }
    public int Store { get; set; }
}
