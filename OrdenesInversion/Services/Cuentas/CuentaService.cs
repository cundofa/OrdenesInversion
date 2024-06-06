using OrdenesInversion.Data;
using OrdenesInversion.Models;

namespace OrdenesInversion.Services.Cuentas;

public class CuentaService : ICuentaService
{
    private readonly DataContext _dataContext;
    public CuentaService(DataContext context)
    {
        _dataContext = context;
    }
    public void CrearCuenta(Cuenta cuenta)
    {
        using (var transaction = _dataContext.Database.BeginTransaction())
        {
            _dataContext.Add(cuenta);
            _dataContext.SaveChanges();
            transaction.Commit();
        }
    }
    public Cuenta GetCuenta(Guid id)
    {
        try
        {
            Cuenta cuenta = _dataContext.Cuentas.Find(id);
            return cuenta;
        }
        catch (Exception ex)
        {

            throw;
        }
    }
}