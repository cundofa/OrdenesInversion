namespace OrdenesInversion.Contracts.Orden;

public record UpdateOrdenRequest(
    Guid id,
    int estadoUpdated
);

