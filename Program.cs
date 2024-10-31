using Microsoft.EntityFrameworkCore;
using TunifyPlatform.Data;

namespace TunifyPlatform
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            //enable the controllers
            builder.Services.AddControllers();
            string ConnectionStringVar = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<TunityDbContext>(optionsX => optionsX.UseSqlServer(ConnectionStringVar));
            var app = builder.Build();
            app.MapControllers();
            builder.Services.AddLogging();


            app.MapGet("/", () => "Hello World!");
            app.MapGet("/newpage", () => "Welcome to my First App");

        

            app.Run();
        }
    }
}
