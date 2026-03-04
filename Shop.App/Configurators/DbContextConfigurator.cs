using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Shop.App.Configurators;
namespace Shop.App.Configurators;

public static class DbContextConfigurator
{
    public static void Configure(DbContextOptionsBuilder options)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        options.UseSqlServer(
            configuration.GetConnectionString("DefaultConnection"));
    }
}
