using Microsoft.Extensions.FileProviders;
using onpe_sql.Controllers.bd;
using onpe_sql.Controllers.dao;

namespace onpe_sql
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddScoped<clsBD>();
            builder.Services.AddScoped<daoParticipacion>();
            builder.Services.AddScoped<daoUbigeo>();

            var app = builder.Build();


            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Participacion}/{action=Inicio}/{id?}");

            app.Run();
        }
    }
}
