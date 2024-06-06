namespace OrdenesInversion.Contracts.Cuenta;

public record CrearCuentaRequest(

    long CvuCliente,
    string NombreCliente,
    string ApellidoCliente
);