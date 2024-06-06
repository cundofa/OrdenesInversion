using OrdenesInversion.Data;
using System.ComponentModel.DataAnnotations;

namespace OrdenesInversion.Models;

public class Orden
{
    [Key]
    public Guid Id { get; set; }
    public Guid IdCuenta { get; set; }
    public int IdActivo { get; set; }
    public int Cantidad { get; set; }
    public int Estado { get; set; }
    public float MontoTotal { get; set; }
    public DateTime FechaCreacion{ get; set; }
    public DateTime FechaUltimaModificacion{ get; set; }
    public bool Baja { get; internal set; }

    public Orden() { }
    public Orden(
    Guid idCuenta,
    int idActivo,
    int cantidad,
    float montoTotal)
    {
        Id = Guid.NewGuid();
        IdCuenta = idCuenta;
        IdActivo = idActivo;
        Cantidad = cantidad;
        Estado = 1;
        MontoTotal = montoTotal;
        FechaCreacion = DateTime.Now;
        FechaUltimaModificacion = DateTime.Now;
    }


}