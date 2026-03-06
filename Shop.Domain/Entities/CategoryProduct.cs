using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Entities;

public class CategoryProduct
{
    [ForeignKey("CategoryId")]
    public Guid? CategoryId { get; set; }
    public Category? Category { get; set; }

    [ForeignKey("ProductId")]
    public Guid? ProductId { get; set; }
    public Product? Product { get; set; }

    [Required]
    [Range(1, 1000, ErrorMessage = "Store must be beetwen 1 and 1000")]
    public int Store { get; set; }
}
