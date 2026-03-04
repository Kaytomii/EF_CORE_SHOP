using Shop.Domain.Enums;
using System.Globalization;

namespace Shop.Domain.Entities;

public class User
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string SurName {  get; set; } = string.Empty;
    public string? Email { get; set; }
    public string? HashPassword { get; set; }
    public UserRole Role { get; set; } = UserRole.USER;
    public DateTime CreatedAt { get; set; }

}
