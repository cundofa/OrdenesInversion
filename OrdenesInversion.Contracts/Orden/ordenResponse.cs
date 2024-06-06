namespace OrdenesInversion.Contracts.Orden;

public record OrdenResponse(

    Guid id,
    Guid idCuenta,
    int idActivo,
    int cantidad,
    string estado,
    float montoTotal,
    DateTime fechaCreacion,
    DateTime fechaUltModificacion
);