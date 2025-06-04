using Microsoft.EntityFrameworkCore;
using Modelos;

namespace CrudProductos.Datos
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // Agregar los Modelos
        public DbSet<Producto> Productos { get; set; }
    }
}
