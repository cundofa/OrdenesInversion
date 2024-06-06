using OrdenesInversion.Data;
using OrdenesInversion.Models;

namespace OrdenesInversion.Services.Ordenes;

public class OrdenService : IOrdenService
{
    private readonly DataContext _dataContext;

    public OrdenService(DataContext context)
    {
        _dataContext = context;
    }
    public void CrearOrden(Orden orden)
    {
        using (var transaction = _dataContext.Database.BeginTransaction())
        {
            _dataContext.Ordenes.Add(orden);
            _dataContext.SaveChanges();
            transaction.Commit();
        }

    }
    public Orden GetOrden(Guid id)
    {
        try
        {
            Orden orden = _dataContext.Ordenes.Where(o => !o.Baja && o.Id == id).First();
            return orden;
        }
        catch (Exception ex)
        {

            throw;
        }
    }
    public Activo GetActivo(int idActivo)
    {
        try
        {
            Activo activo = _dataContext.Activos.Find(idActivo);
            return activo;
        }
        catch (Exception ex)
        {

            throw;
        }
    }

    public string GetEstadoOrden(int estado)
    {
        try
        {
            Estado estadoOrden = _dataContext.Estados.Find(estado);
            return estadoOrden.Descripcion;
        }
        catch (Exception ex)
        {

            throw;
        }
    }
    public Orden UpdateEstado(Guid id, int estado)
    {
        try
        {
            using (var transaction = _dataContext.Database.BeginTransaction())
            {
                var orden = _dataContext.Ordenes.Find(id);
                orden.Estado = estado;
                orden.FechaUltimaModificacion = DateTime.Now;
                _dataContext.SaveChanges();
                transaction.Commit();
                return orden;
            }
                
        }
        catch (Exception ex)
        {

            throw;
        }
    }
    public Orden DeleteOrden(Guid id)
    {
        try
        {
            using (var transaction = _dataContext.Database.BeginTransaction())
            {
                var orden = _dataContext.Ordenes.Find(id);
                orden.Baja = true;
                orden.FechaUltimaModificacion = DateTime.Now;
                _dataContext.SaveChanges();
                transaction.Commit();
                return orden;
            }

        }
        catch (Exception ex)
        {

            throw;
        }
    }
}