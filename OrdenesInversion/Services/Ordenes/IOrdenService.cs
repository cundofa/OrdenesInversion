using OrdenesInversion.Models;

namespace OrdenesInversion.Services.Ordenes;

public interface IOrdenService
{
    void CrearOrden(Orden orden);
    Orden DeleteOrden(Guid id);
    Orden GetOrden(Guid id);
    Activo GetActivo(int idActivo);
    string GetEstadoOrden(int estado);
    Orden UpdateEstado(Guid id, int estadoUpdated);
}