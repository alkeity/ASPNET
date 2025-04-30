using System.Reflection;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Homework1_Restaurant.Services;
using Homework1_Restaurant.Services.Implementations;

namespace Homework1_Restaurant
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();

            //builder.Services.AddSingleton<IRestaurantService, RestaurantService>();
            //builder.Services.AddSingleton<IMenuService, MenuService>();

            // autofac

            builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

            builder.Host.ConfigureContainer<ContainerBuilder>
                (
                containerBuilder =>
                {
                    Assembly assembly = typeof(Program).Assembly;
                    containerBuilder.RegisterAssemblyTypes(assembly)
                    .Where(service => service.Name.EndsWith("Service"))
                    .AsImplementedInterfaces().InstancePerLifetimeScope();
                }
                );

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}
