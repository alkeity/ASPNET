namespace Homework5_MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<Services.IGreetingService, Services.Implementations.GreetingService>();
            builder.Services.AddScoped<Services.IRecordService, Services.Implementations.RecordServiceJson>();
            builder.Services.AddScoped<Services.IReviewService, Services.Implementations.ReviewService>();

            var app = builder.Build();

            app.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
