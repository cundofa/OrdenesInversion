
namespace OrdenesUnitTesting
{
    public class OrdenesTesting
    {
        private readonly OrdenesController _controllerOrdenes;
        private readonly IOrdenService _serviceOrdenes;
        private readonly DataContext _dataContext;

        public OrdenesTesting()
        {
            var options = new DbContextOptionsBuilder<DataContext>()
                //acá debería haber una base de testing para no modificar prod con el update ni el create
                .UseSqlServer("Server=localhost;Database=OrdenesInversionDb;Trusted_Connection=true;TrustServerCertificate=true;") 
                .Options;
            _dataContext = new DataContext(options);
            _serviceOrdenes = new OrdenService(_dataContext);
            _controllerOrdenes = new OrdenesController(_serviceOrdenes);
            
        }
        [Fact]
        public void Get_Orden_Ok()
        {
            var result = _controllerOrdenes.GetOrden(Guid.Parse("D239E298-613B-4286-92D9-A42967E22264"));//pegar Orden.ID desde la db

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void Create_Orden_Ok()
        {
            CrearOrdenRequest request = new(Guid.Parse("2D7C4E72-C78A-4761-A7BF-3F03F372BD4B"), 4, 5);//pegar Orden.ID desde la db
            var result = _controllerOrdenes.CrearOrden(request);

            Assert.IsType<CreatedAtActionResult>(result);
        }
        [Fact]
        public void Update_Orden_Ok()
        {
            UpdateOrdenRequest request = new(Guid.Parse("D239E298-613B-4286-92D9-A42967E22264"), 3);//pegar Orden.ID desde la db
            var result = _controllerOrdenes.UpdateOrden(request);

            Assert.IsType<CreatedAtActionResult>(result);
        }
        [Fact]
        public void Delete_Orden_Ok()
        {
            var result = _controllerOrdenes.DeleteOrden(Guid.Parse("3B54D048-7749-4B7A-9DAD-9E64C14F71B2"));//pegar Orden.ID desde la db

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void Get_Orden_NoContent()
        {
            var result = _controllerOrdenes.GetOrden(Guid.Parse("3B54D048-7749-4B7A-9DAD-9E64C14F71B2"));//pegar Orden.ID desde la db

            Assert.IsType<NoContentResult>(result);
        }
    }
}