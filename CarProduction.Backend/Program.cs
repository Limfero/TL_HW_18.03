using CarProduction.Repositories;
using CarProduction.Service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddScoped<IManufacturerRepository>(s =>
    new ManufacturerRepository(builder.Configuration.GetValue<string>("DefaultConnection")));
builder.Services.AddScoped<IManufacturerService, ManufacturerService>();

builder.Services.AddScoped<ICarRepository>(s =>
    new CarRepository(builder.Configuration.GetValue<string>("DefaultConnection")));
builder.Services.AddScoped<ICarService, CarService>();

builder.Services.AddScoped<ICarDealershipRepository>(s =>
    new CarDealershipRepository(builder.Configuration.GetValue<string>("DefaultConnection")));
builder.Services.AddScoped<ICarDealershipService, CarDealershipService>();

builder.Services.AddScoped<IPurchaseOrderRepository>(s =>
    new PurchaseOrderRepository(builder.Configuration.GetValue<string>("DefaultConnection")));
builder.Services.AddScoped<IPurchaseOrderService, PurchaseOrderService>();

var app = builder.Build();
app.MapControllers();
app.Run();
