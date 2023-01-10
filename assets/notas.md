# ejecutar live server
dotnet watch run

- Formas de acceder a un endpoint por Rutas
[HttpGet(Name = "GetWeatherForecast")]
[Route("get/climas")]
[Route("get/climaz")]
[Route("[action]")]  // con el nombre del metodo podemos acceder a la función del endpoint 
public IEnumerable<WeatherFo

# Minimal API
API con estilo minimaliosta
Reduce las lineas de codigo
dotnet new web

# Middleware   -----Z app.use()
- serie de instrucciones que se agregan al ciclo de vida de una peticion http
- provee una ejecucion de peticiones a traves de capas
- facilitan la implementacion de interceptores y filtros sobre las peticiones en una API