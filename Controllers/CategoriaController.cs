using Microsoft.AspNetCore.Mvc;
using webapi.Models;
using webAPI.Services;

namespace webAPI.Controllers;

[Route("api/[controller]")]
public class CategoriaController : ControllerBase
{
    protected readonly ICategoriaService _categoria;

    public CategoriaController(ICategoriaService service)
    {
        _categoria = service;
    }
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_categoria.Get());
    }
    [HttpPost]
    public IActionResult Post([FromBody]Categoria categoria)
    {
        return Ok(_categoria.Save(categoria));
    }
    [HttpPut("{id}")]
    public IActionResult Put(Guid id,[FromBody]Categoria categoria)
    {
        _categoria.Update(id, categoria);
        return Ok();         
    }
    
    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        _categoria.Delete(id);
        return Ok();
    }
}

