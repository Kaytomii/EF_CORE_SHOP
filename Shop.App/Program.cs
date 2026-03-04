using Microsoft.Extensions.DependencyInjection;
using Shop.App.Configurators;
using Shop.App.Data;
using Shop.Domain.Entities;
using Shop.Domain.Enums;
namespace Shop.App;

internal class Program
{
    static void Main(string[] args)
    {
        var services = new ServiceCollection();

        services.AddDbContext<ShopDbContext>(options =>
        {
            DbContextConfigurator.Configure(options);
        });

        var provider = services.BuildServiceProvider();

        using var scope = provider.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<ShopDbContext>();

        if (context.Database.CanConnect())
        {
            Console.WriteLine("Пiдключення до БД встановлено");
            User user = new User();
            user.Name = "Bob";
            user.SurName = "Alex";
            user.Email = "emailbob@gmail.com";
            user.Role = UserRole.ADMIN;
            user.HashPassword = BCrypt.Net.BCrypt.EnhancedHashPassword("qwerty");
            context.Users.Add(user);
            context.SaveChanges();
            //string email = "emailalex@gmail.com";
            //string password = "qwerty";
            //var user = context.Users.FirstOrDefault(u => u.Email == email);

            //if (user != null)
            //{
            //    if(BCrypt.Net.BCrypt.EnhancedVerify(password, user.HashPassword))
            //    {
            //        Console.WriteLine("Login");
            //    }
            //}
        }
        else
        {
            Console.WriteLine("Не вдалось підключитись до БД");
        }
    }
}
