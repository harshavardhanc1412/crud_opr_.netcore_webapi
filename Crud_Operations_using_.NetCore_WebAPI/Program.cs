
using Crud_Operations_using_.NetCore_WebAPI.Models;
using Microsoft.EntityFrameworkCore;


namespace Crud_Operations_using_.NetCore_WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            
            // Add services to the container.
            builder.Services.AddDbContext<BrandContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("BrandCS")));

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddKendo();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();
            app.UseRouting();
            //app.UseKendo();

            app.MapControllers();

            app.Run();
        }
    }
}
