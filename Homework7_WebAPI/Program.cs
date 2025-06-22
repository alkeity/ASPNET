
using Homework7_WebAPI.Data;
using Homework7_WebAPI.Services;
using Homework7_WebAPI.Services.Implementations;
using Microsoft.EntityFrameworkCore;

namespace Homework7_WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<IStorageService, StorageService>();

            builder.Services.AddDbContext<AppDbContext>
                (
                options =>
                {
                    string? connectionString = builder.Configuration.GetConnectionString("Default");
                    if (connectionString == null) throw new MissingFieldException("Failed to get connection string.");

                    options.UseSqlServer(connectionString);
                }
                );

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
