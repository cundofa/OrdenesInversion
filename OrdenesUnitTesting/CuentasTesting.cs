using OrdenesInversion.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdenesUnitTesting
{
    public class CuentasTesting
    {
        private readonly CuentasController _controllerCuentas;
        private readonly ICuentaService _serviceCuenta;
        private readonly DataContext _dataContext;
        public CuentasTesting()
        {
            var options = new DbContextOptionsBuilder<DataContext>()
                //acá debería haber una base de testing para no modificar prod con el update ni el create
                .UseSqlServer("Server=localhost;Database=OrdenesInversionDb;Trusted_Connection=true;TrustServerCertificate=true;")
                .Options;
            _dataContext = new DataContext(options);
            _serviceCuenta = new CuentaService(_dataContext);
            _controllerCuentas = new CuentasController(_serviceCuenta);
        }

        [Fact]
        public void Create_Cuenta_Ok()
        {
            CrearCuentaRequest request = new(987654321123, "Ezequiel", "Insua");
            var result = _controllerCuentas.CrearCuenta(request);

            Assert.IsType<CreatedAtActionResult>(result);
        }
        [Fact]
        public void Get_Cuenta_Ok()
        {
            var result = _controllerCuentas.GetCuenta(Guid.Parse("7BDE032E-1D83-46AE-A0AB-AA196DC90B5C"));

            Assert.IsType<OkObjectResult>(result);
        }
    }
}
