using FastStore.Api.Data;
using Microsoft.EntityFrameworkCore;
using FastStore.Api.Services;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;// Evita problemas de referencia circular al serializar entidades relacionadas
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());// Agrega el convertidor para serializar enums como strings
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IInventoryService, InventoryService>();
builder.Services.AddScoped<IOrderService, OrderService>();

// AGREGAR CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular",
        policy =>
        {
            policy.WithOrigins("http://localhost:4200")
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

var app = builder.Build();

// USAR CORS (ANTES de MapControllers)
app.UseCors("AllowAngular");

// Validar la conexión a la base de datos al iniciar la aplicación
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection(); // Deshabilitado para pruebas locales con Angular

app.MapControllers();

app.Run();