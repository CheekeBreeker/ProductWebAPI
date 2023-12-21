using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProductWebAPI.Configuration;
using ProductWebAPI.Controllers;
using ProductWebAPI.Models;

namespace ProductWebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var connectionString = builder.Configuration.GetConnectionString("ProductAppConnectionString");



            builder.Services.AddDbContext<ProductAppContext>(options => options.UseSqlite(connectionString));

            builder.Services.AddControllers();

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MapperProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            builder.Services.AddSingleton(mapper);

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

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