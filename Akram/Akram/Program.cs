
using Akram.Models.DBc;
using Akram.Models.Navigator;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

using System.Runtime.CompilerServices;

namespace Akram
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
            string? connectionStrings = builder.Configuration.GetConnectionString("db");



            builder.Services.AddDbContext<Dbase>(w => w.UseSqlServer(connectionStrings));
            builder.Services.AddScoped<IAccountNavigation,AccountNavigation>();
            builder.Services.AddAutoMapper(typeof(Program));
            
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
