using Microsoft.EntityFrameworkCore;
using OrdenesInversion.Models;

namespace OrdenesInversion.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) :base(options) 
        {
        }
        public DbSet<Orden> Ordenes { get; set; }
        public DbSet<Activo> Activos { get; set; }
        public DbSet<Cuenta> Cuentas { get; set; }
        public DbSet<Estado> Estados { get; set; }
        public DbSet<TipoActivo> TipoActivos { get; set; }

    }
}
