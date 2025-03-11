using Library.Context;
using Library.Models.Domain;
using Library.Services;
using Library.Services.IServices;
using LLibrary.Services.IServices;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Configuración de servicios
builder.Services.AddControllers();

// Configuración de la base de datos
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Inyección de dependencias de los servicios
builder.Services.AddTransient<IGaleriaService, GaleriaService>();
builder.Services.AddTransient<IAuthorServices, AuthorService>();
builder.Services.AddTransient<IFotografiaService, FotografiaService>();
builder.Services.AddTransient<ICategoriaService, CategoriaService>();

// Configuración de Swagger para la documentación de la API
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Mi API",
        Version = "v1",
        Description = "Documentación de mi API con Swagger"
    });
});

var app = builder.Build();

// Configuración de middleware y manejo de errores
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");  // Asegúrate de tener una página de error
    app.UseHsts();
}

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Mi API v1");
    c.RoutePrefix = "";  // Configura la ruta base de Swagger
});

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.MapControllers();
app.UseAuthorization();

app.Run();
