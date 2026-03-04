using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.App.Configurators;

public class ConfigurationUser : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Id)
               .HasName("PrimaryKey_UserId");

        builder.Property(u => u.Email)
               .IsRequired();

        builder.HasIndex(u => u.Email)
               .IsUnique();

        builder.Property(r => r.Role)
            .IsRequired();

        builder.ToTable(r => r.HasCheckConstraint("RoleCheck", "[Role] BETWEEN 0 AND 3"));

        builder.Property(n => n.Name)
            .IsRequired();

        builder.ToTable(n => n.HasCheckConstraint("MinNameLength", "LEN(Name) >= 1"));

        builder.Property(sub => sub.SurName)
            .IsRequired();

        builder.ToTable(sub => sub.HasCheckConstraint("MinSurNameLength", "LEN(SurName) >= 1"));

        builder.Property(u => u.CreatedAt)
               .HasDefaultValueSql("SYSDATETIME()");
    }
}
