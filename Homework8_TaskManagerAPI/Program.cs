
using Homework8_TaskManagerAPI.Data;
using Homework8_TaskManagerAPI.Services;
using Homework8_TaskManagerAPI.Services.Implementations;
using Microsoft.EntityFrameworkCore;

namespace Homework8_TaskManagerAPI
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

            builder.Services.AddScoped<ITaskService, TaskService>();

            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                string? connectionString = builder.Configuration.GetConnectionString("Default");

                if (connectionString == null)
                    throw new MissingFieldException("Failed to get default connection string");

                options.UseSqlServer(connectionString);
            });

            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(policy =>
                {
                    policy.AllowAnyOrigin()
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                });
            });

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
