using Homework6_MVC.Services;
using Homework6_MVC.Services.Implementations;

namespace Homework6_MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<ICalcService, CalcService>();

            var app = builder.Build();

            app.MapControllerRoute("default", "{controller=Calc}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
