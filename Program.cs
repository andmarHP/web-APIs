// using webAPI.Middlewares;
using webAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//inyección de dependencias de servicio de HelloWorldService - primer forma de inyeccion de dependencia
builder.Services.AddScoped<IHelloWorldService, HelloWorldServices>();

//inyección de dependencias de servicio de HelloWorldService - segunda forma de inyeccion de dependencia (lambda)
builder.Services.AddScoped<IHelloWorldService>(p => new HelloWorldServices());
builder.Services.AddScoped<ICategoriaService,CategoriaService>();
builder.Services.AddScoped<ITareasService,TareasService>();

var app = builder.Build();

// Configure the HTTP request pipeline. //configure Swagger in develop - not in production
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
// app.UseTimeMiddleware();

app.MapControllers();

app.Run();
