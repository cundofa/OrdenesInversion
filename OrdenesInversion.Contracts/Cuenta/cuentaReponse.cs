namespace OrdenesInversion.Contracts.Cuenta;

public record CuentaResponse(

    Guid id,
    long CvuCliente,
    string NombreCliente,
    string ApellidoCliente

);