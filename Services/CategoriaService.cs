using webapi;
using webapi.Models;

namespace webAPI.Services; 

public class CategoriaService : ICategoriaService
{
    TareasContext context;
    public CategoriaService(TareasContext dbcontext)
    {
        context = dbcontext;
    }
    //get
    public IEnumerable<Categoria> Get()
    {
        return context.Categorias;
    }
    //post
    public async Task Save(Categoria categoria)
    {
        context.Add(categoria);
        await context.SaveChangesAsync();
    }
    //put
    public async Task Update(Guid id, Categoria categoria)
    {
        //buscar el id
        var categoriaActual = context.Categorias.Find(id);

        if (categoriaActual != null)
        {
            categoriaActual.Nombre = categoria.Nombre;
            categoriaActual.Descripcion = categoria.Descripcion;
            categoriaActual.Peso = categoria.Peso;
        
            await context.SaveChangesAsync();
        }
    }

    //Delete
    public async Task Delete(Guid id)
    {
        //buscar el id
        var categoriaActual = context.Categorias.Find(id);

        if (categoriaActual != null)
        {
            context.Remove(categoriaActual);
            await context.SaveChangesAsync();
        }
    }
}
public interface ICategoriaService
{
    IEnumerable<Categoria> Get();
    Task Save(Categoria categoria);
    Task Update(Guid id, Categoria categoria);
    Task Delete(Guid id);
}
