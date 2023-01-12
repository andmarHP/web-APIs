using webapi;
using webapi.Models;

namespace webAPI.Services;

public class TareasService : ITareasService
{
    TareasContext context;
    public TareasService(TareasContext dbcontext)
    {
        context = dbcontext;
    }    

    //get
    public IEnumerable<Tarea> Get()
    {
        return context.Tareas;
    }

    //post 
    public async Task Save(Tarea tarea)
    {
        tarea.FechaCreacion = DateTime.Now;
        context.Add(tarea);
        await context.SaveChangesAsync();
    }
    //put
    public async Task Update(Guid id, Tarea tarea)
    {
        var tareaActual = context.Tareas.Find(id);

        if (tareaActual != null)
        {
            tareaActual.Titulo = tarea.Titulo;
            tareaActual.Descripcion = tarea.Descripcion;
            tareaActual.PrioridadTarea = tarea.PrioridadTarea;
            tareaActual.CategoriaId = tarea.CategoriaId;

            await context.SaveChangesAsync();
        }
    }

    //Delete
    public async Task Delete(Guid id)
    {
        var tareaActual = await context.Tareas.FindAsync(id);

        if (tareaActual != null)
        {
            context.Remove(tareaActual);
            await context.SaveChangesAsync();
        }
    }
}

public interface ITareasService
{
    IEnumerable<Tarea> Get();
    Task Save(Tarea tarea);
    Task Update(Guid id, Tarea tarea);
    Task Delete(Guid id);

}