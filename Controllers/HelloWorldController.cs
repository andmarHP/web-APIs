using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using webAPI.Models;
using webAPI.Services;

namespace webAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HelloWorldController : ControllerBase
{
    IHelloWorldService helloWorldServices;

    public HelloWorldController(IHelloWorldService helloWorld)
    {
        helloWorldServices = helloWorld;
    }
    //uso de interfaz inyectada por dependencia
    [HttpGet("getHello")]
    public IActionResult Get()
    {
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

    [HttpGet("Boletos")]
    public IActionResult GetBoletoss()
    {
        return Ok(helloWorldServices.GetBoletos());
    }
    [HttpGet("upper")]
    public ActionResult<List<Boleto>> toUpper()
    {
        var miLista = helloWorldServices.GetBoletos();
        var nuevaLista = new List<Boleto>();

        foreach (var item in miLista)
        {
            
        } 
        return miLista;       
    }
}
