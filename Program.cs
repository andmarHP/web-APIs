using webAPI.Middlewares;
using webAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//inyección de dependencias de servicio de HelloWorldService
builder.Services.AddScoped<IHelloWorldService, HelloWorldServices>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

//middleware para mostrar la pagina de bienvenida cada que se consuma la API
// app.UseWelcomePage();

//implementar el middleware TimeMiddleware
app.UseTimeMiddleware();

app.MapControllers();

app.Run();
