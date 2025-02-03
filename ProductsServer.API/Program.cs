using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProductsServer.Application;
using ProductsServer.Infrastructure;
using ProductsServer.Infrastructure.Mappings;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Configure logging
        builder.Logging.ClearProviders();
        builder.Logging.AddConsole();
        builder.Logging.AddDebug();
        builder.Logging.SetMinimumLevel(LogLevel.Trace);

        try
        {
            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Register application services
            // ProductCategory 
            builder.Services.AddScoped<IProductCategoryRepository, ProductCategoryRepository>();
            builder.Services.AddScoped<IProductCategoryService, ProductCategoryService>();

            // products 
            builder.Services.AddScoped<IProductsRepository, ProductsRepository>();
            builder.Services.AddScoped<IProductService, ProductService>();

            // AutoMapper
            builder.Services.AddAutoMapper(typeof(DALMappingProfile));

            // Register ApplicationDbContext with SQL Server provider
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("DefaultConnection"),
                    sqlServerOptionsAction: sqlOptions =>
                    {
                        //sqlOptions.EnableRetailMode(); // Optional: improved error handling
                        sqlOptions.CommandTimeout(30); // Optional: set command timeout
                    }
                )
            );

            var app = builder.Build();

            // Ensure database is created and migrations are applied
            using (var scope = app.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
            }

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            //app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
        catch (Exception ex)
        {
            // Catch any unhandled exceptions during startup
            var logger = LoggerFactory.Create(config =>
            {
                config.AddConsole();
            }).CreateLogger<Program>();

            logger.LogCritical(ex, "Host terminated unexpectedly");
            throw;
        }
    }
}