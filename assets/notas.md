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

# Logger 
Podemos colocar mensajes en la consola
usado cuando tenemos montado el servidor en la nube.
- Entender los mensajes que nos arroja el server por medio de los logs

niveles del logs
- Trace 0
- Debug 1
- Information 2
- Warnings 3
- Errors 4
- Critical 5
- None 6

Podemos configurar los niveles del logs en app.setting en el apartado log-levels


# Swashbuckle
Tiene la libreria que nos permite configurar Swagger dentro de nuestra solución

Para que Swager genere la documentacion debemos configurar el openIA y seguir el estandar.
Colocar el verbo de manera correcta para que swagger pueda mostrarnos los endpoints
- Swager se usa solo en develop ya que se puede acceder a sus endpoint(hacker) y conocer la estructura del proyecto.

# Remover paquetes
dotnet remove package "package name"
dotnet remove package Microsoft.EntityFrameworkCore.InMemory