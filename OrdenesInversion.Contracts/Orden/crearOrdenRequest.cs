namespace OrdenesInversion.Contracts.Orden;

public record CrearOrdenRequest(

    Guid idCuenta,
    int idActivo,
    int cantidad
);