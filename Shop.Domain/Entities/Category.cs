using System.ComponentModel.DataAnnotations;

namespace Shop.Domain.Entities;

public class Category
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    [MaxLength(1000, ErrorMessage = "name cannot exceed 1000 characters")]
    public string Name { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; }

    public ICollection<CategoryProduct>? Categories { get; set; } = new List<CategoryProduct>();
} 
