using API.Extensions;
using API.HelperInAPI;
using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
//builder.Services.AddScoped(typeof(IGenericRepository<>), (typeof(GenericRepository<>)));
builder.Services.AddAutoMapper(typeof(MappingProfiles));
builder.Services.AddLogging();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerConfig();
builder.Services.UseApplicationServiceAdd();

builder.Services.AddDbContext<StoreDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddCors(options=>
{
    options.AddPolicy("CorsPolicy", po =>
    {
        po.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://localhost:4200");
    });
});
var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    
}
app.AddSwaggerConfigInApp();
app.UseStatusCodePagesWithReExecute("error/{0}");
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseCors("CorsPolicy");
app.UseAuthorization();

app.MapControllers();

// Create a scope and use the services
using (var scope = app.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;
    var loggerFactory = serviceProvider.GetRequiredService<ILoggerFactory>();
    try
    {
        var dbContext = serviceProvider.GetRequiredService<StoreDbContext>();
        await dbContext.Database.MigrateAsync();
        //await StoreContextSeed.SeedAsync(dbContext, loggerFactory);
    }
    catch
    {

        var logger = loggerFactory.CreateLogger<Program>();
        logger.LogInformation("Logger is configured and ready to use.");
    }
}

app.Run();
