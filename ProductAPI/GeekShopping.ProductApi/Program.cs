

using AutoMapper;
using GeekShopping.ProductApi.Config;
using GeekShopping.ProductApi.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Simple.ProductApi.Context;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllers();

        // Configuration
        var configuration = new ConfigurationBuilder()
            .SetBasePath(builder.Environment.ContentRootPath)
            .AddJsonFile("appsettings.json")
            .Build();

        // Database Configuration
        var connectionString = configuration.GetConnectionString("MySqlConnectionString");
        builder.Services.AddDbContext<MySqlContext>(options =>
            options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 30))));

        IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
        builder.Services.AddSingleton(mapper);
        builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        builder.Services.AddScoped<IProductRepository, ProductRepository>();

        // Swagger
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "ProductApi", Version= "v1" });
        });

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}
