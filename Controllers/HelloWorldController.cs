using System.Xml;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using webAPI.Services;

namespace webAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HelloWorldController : ControllerBase
{
    IHelloWorldService helloWorldServices;
    //logger 
    private readonly ILogger<HelloWorldController> _logger;

    public HelloWorldController(IHelloWorldService helloWorld,
                                ILogger<HelloWorldController> logger 
                                )
    {
        helloWorldServices = helloWorld;
        _logger = logger;
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

}
