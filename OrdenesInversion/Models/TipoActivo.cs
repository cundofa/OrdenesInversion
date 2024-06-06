using System.ComponentModel.DataAnnotations;

namespace OrdenesInversion.Models;

public class TipoActivo
{
    public TipoActivo()
    {
    }
    [Key]
    public int Id { get; set; }
    public string Descripcion { get; set; }
}