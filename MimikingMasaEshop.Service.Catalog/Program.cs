using System.Reflection;
using MimikingMasaEshop.Service.Catalog.Infrastructure;
using MimikingMasaEshop.Service.Catalog.Infrastructure.Middleware;
using MimikingMasaEshop.Service.Catalog.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddControllers();
#region  注册Swagger
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
#endregion

builder.Services.AddMapster();
builder.Services.AddSequentialGuidGenerator();
builder.Services.Configure<AuditEntityOptions>(options => options.UserIdType = typeof(int));
builder.Services.AddMasaDbContext<CatalogDbContext>(builder =>
{
    builder
    .UseSqlite()
    .UseFilter();
});
builder.Services.AddMultilevelCache(options =>
{
    options.UseStackExchangeRedisCache();
});
builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
builder.Services.AddDomainEventBus(options =>
{
    options.UseIntegrationEventBus(bus => bus.UseDapr().UseEventLog<CatalogDbContext>())
    .UseEventBus(bus => bus.UseMiddleware(typeof(LoggingMiddleware<>)))
    .UseUoW<CatalogDbContext>()
    .UseRepository<CatalogDbContext>();
});

builder.Services.AddI18n();
GlobalMappingConfig.Mapping();

var app = builder.AddServices();

app.UseI18n();

app.UseMasaExceptionHandler(options =>
{
    options.ExceptionHandler = contextMarshalException =>
    {

    };
});

// Configure the HTTP request pipeline.
#region 使用Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
#endregion

await app.MigrateDbContextAsync<CatalogDbContext>(async (context, serviceProvider) =>
{
    await CatalogDbContextSeed.SeedAsync(context, serviceProvider);
});

//app.UseHttpsRedirection();

//app.UseAuthorization();

//app.MapControllers();

app.Run();
