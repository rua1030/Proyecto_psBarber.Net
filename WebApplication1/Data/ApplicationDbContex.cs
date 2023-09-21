using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Rol> Rol { get; set; }

        public DbSet<Cliente> Cliente { get; set; }

        public DbSet<Venta> venta  { get; set; }

        public DbSet<Detalle_Venta> Detalle_Venta { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuración de relaciones

            // Relación entre Cliente y Venta (uno a muchos)
            modelBuilder.Entity<Venta>()
                .HasOne(v => v.Cliente)
                .WithMany(c => c.Venta)
                .HasForeignKey(v => v.id_Cliente);

            // Relación entre Venta y Detalle_Venta (uno a muchos)
            modelBuilder.Entity<Detalle_Venta>()
                .HasOne(dv => dv.Venta)
                .WithMany(v => v.Detalle_Ventas)
                .HasForeignKey(dv => dv.id_Venta);


            

            base.OnModelCreating(modelBuilder);
        }


    }
}
