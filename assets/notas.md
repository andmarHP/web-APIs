# ejecutar live server
dotnet watch run

- Formas de acceder a un endpoint por Rutas
[HttpGet(Name = "GetWeatherForecast")]
[Route("get/climas")]
[Route("get/climaz")]
[Route("[action]")]  // con el nombre del metodo podemos acceder a la función del endpoint 
public IEnumerable<WeatherFo