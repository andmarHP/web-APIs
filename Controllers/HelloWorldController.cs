using System.Xml;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using webAPI.Services;
using webapi;

namespace webAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HelloWorldController : ControllerBase
{
    IHelloWorldService helloWorldServices;
    //conexion a bd
    TareasContext dbcontext;
    //logger 
    private readonly ILogger<HelloWorldController> _logger;

    public HelloWorldController(IHelloWorldService helloWorld,
                                ILogger<HelloWorldController> logger,
                                TareasContext db
                                )
    {
        helloWorldServices = helloWorld;
        _logger = logger;
        dbcontext = db;
    }
    //uso de interfaz inyectada por dependencia
    [HttpGet("getHello")]
    public IActionResult Get()
    {
        _logger.LogDebug("Este es un mensaje de hola en un log tipo debug");
        return Ok(helloWorldServices.GetHelloWorld()); //usar metodo del servicio helloworld service
    }

    [HttpGet("getNumeros")]
    public ActionResult<IEnumerable<int>> GetNumbers()
    {
        return Ok(helloWorldServices.GetNumeros()); //usar metodo del servicio
    }

    [HttpGet("total")]
    public int Total()
    {
        int tot = 0;
        IEnumerable<int> lst = helloWorldServices.GetNumeros();
        foreach (var item in lst)
        {
            tot += item;
        }

        return tot;
    }

    //Metodo para crear la conexion a la base de datos, con la configuracion de la FluentAPI
    [HttpGet]
    [Route("create_db")]
    public IActionResult CreateDatabase()
    {
        dbcontext.Database.EnsureCreated(); //Metodo para asegurar que se conecte a database
        return Ok();
    } 

}
