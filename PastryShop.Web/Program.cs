using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PastryShop.DAL;

namespace PastryShop.Web
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            await ConfigureDB(host);

            await host.RunAsync();
        }

        private static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        private static async Task ConfigureDB(IHost host)
        {
            using var services = host.Services.CreateScope();
            var context = services.ServiceProvider.GetService<PastryDbContext>();

            await context.Database.MigrateAsync(); // apply all migrations
            await SeedData.Initialize(context); // Insert default data
        }
    }
}
