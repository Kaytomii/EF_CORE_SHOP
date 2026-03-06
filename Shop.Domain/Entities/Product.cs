using System.ComponentModel.DataAnnotations;

namespace Shop.Domain.Entities;

public class Product
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    [MaxLength(1000, ErrorMessage = "Name cannot exceed 1000 characters")]
    public string Name { get; set; } = string.Empty;

    [Required]
    [Range(0, 10000000, ErrorMessage = "Price must be greater than 0")]
    public decimal Price { get; set; }
    public DateTime CreatedAt { get; set; }

    public ICollection<CategoryProduct>? Categories { get; set; } = new List<CategoryProduct>();
}
