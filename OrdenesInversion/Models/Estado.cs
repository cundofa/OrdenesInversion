using System.ComponentModel.DataAnnotations;

namespace OrdenesInversion.Models;

public class Estado
{
    public Estado() { }
    [Key]
    public int Id { get; set; }
    public string Descripcion { get; set; }
}