using System.ComponentModel.DataAnnotations;

namespace OrdenesInversion.Models;

public class Cuenta
{
    public Cuenta(
        long cvuCliente,
        string nombreCliente,
        string apellidoCliente
    )
    {
        Id = Guid.NewGuid();
        this.CvuCliente = cvuCliente;
        this.NombreCliente = nombreCliente;
        this.ApellidoCliente = apellidoCliente;
    }
    [Key]
    public Guid Id { get; set; }
    public long CvuCliente { get; set; }
    public string NombreCliente { get; set; }
    public string ApellidoCliente { get; set; }
}