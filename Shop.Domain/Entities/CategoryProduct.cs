using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Entities;

public class CategoryProduct
{
<<<<<<< Updated upstream
    public Guid? CategoryId { get; set; }
    public Category? Category { get; set; }
=======
    [Key, ForeignKey("CategoryId")]
    public Guid? CategoryId { get; set; }
    public Category? Category { get; set; }

    [Key, ForeignKey("ProductId")]
>>>>>>> Stashed changes
    public Guid? ProductId { get; set; }
    public Product? Product { get; set; }
    public int Store { get; set; }
}
