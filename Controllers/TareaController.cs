using Microsoft.AspNetCore.Mvc;
using webapi.Models;
using webAPI.Services;

namespace webAPI.Controllers;

[Route("api/[controller]")]
public class TareaController : ControllerBase
{
    protected readonly ITareasService _tarea;

    public TareaController(ITareasService service)
    {
        _tarea = service;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_tarea.Get());
    }

    [HttpPost]
    public IActionResult Post([FromBody]Tarea tarea)
    {
        _tarea.Save(tarea);
        return Ok();
    }
    [HttpPut("{id}")]
    public IActionResult Put(Guid id, [FromBody]Tarea tarea)
    {
        _tarea.Update(id, tarea);
        return Ok();
    }
    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        _tarea.Delete(id);
        return Ok();
    }
}
