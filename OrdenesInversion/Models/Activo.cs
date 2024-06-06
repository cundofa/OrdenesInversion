using System.ComponentModel.DataAnnotations;

namespace OrdenesInversion.Models;

public class Activo
{
    
    public Activo() { }
    [Key]
    public int Id { get; set; }
    public string Ticker { get; set; }
    public string Nombre { get; set; }
    public int TipoActivo { get; set; }
    public float PrecioUnitario { get; set; }
}