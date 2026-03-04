using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Shop.App.Configurators;
namespace Shop.App.Data;

public class ShopDbContextFactory : IDesignTimeDbContextFactory<ShopDbContext>
{
    public ShopDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ShopDbContext>();

        DbContextConfigurator.Configure(optionsBuilder);

        return new ShopDbContext(optionsBuilder.Options);
    }
}
