using Gym_Proyect.Context;
using Gym_Proyect.Models;
using Microsoft.EntityFrameworkCore;

namespace Gym_Proyect.Data
{
    public class GymDBContext : DbContext
    {
        public GymDBContext(DbContextOptions<GymDBContext> options) : base(options) { }

        // Tablas
        public DbSet<TipoUsuario> TipoUsuarios { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Plan> Planes { get; set; }
        public DbSet<DetallePlan> DetallePlanes { get; set; }
        public DbSet<ClientePlan> ClientePlanes { get; set; }
        public DbSet<Turno> Turnos { get; set; }
        public DbSet<Movimiento> Movimientos { get; set; }
        public DbSet<AsistenciaGeneral> AsistenciasGenerales { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Relación: Usuario tiene un TipoUsuario
            modelBuilder.Entity<Usuario>()
                .HasOne(u => u.TipoUsuario)
                .WithMany()
                .HasForeignKey(u => u.tipo_UsuarioID);

            // Relación: ClientePlan (Muchos a Muchos entre Cliente y Plan)
            modelBuilder.Entity<ClientePlan>()
                .HasKey(cp => new { cp.ClienteID, cp.PlanID });

            modelBuilder.Entity<ClientePlan>()
                .HasOne(cp => cp.Cliente)
                .WithMany(c => c.ClientePlanes)
                .HasForeignKey(cp => cp.ClienteID);

            modelBuilder.Entity<ClientePlan>()
                .HasOne(cp => cp.Plan)
                .WithMany(p => p.ClientePlanes)
                .HasForeignKey(cp => cp.PlanID);

            // Relación: DetallePlanes pertenece a un Plan
            modelBuilder.Entity<DetallePlan>()
                .HasOne(dp => dp.Plan)
                .WithMany(p => p.Detalles)
                .HasForeignKey(dp => dp.PlanID);

            // Relación: Movimientos se vincula con Usuarios y Turnos
            modelBuilder.Entity<Movimiento>()
                .HasOne(m => m.Turno)
                .WithMany()
                .HasForeignKey(m => m.TurnoID);

            modelBuilder.Entity<Movimiento>()
                .HasOne(m => m.Usuario)
                .WithMany()
                .HasForeignKey(m => m.UsuarioID)
                .OnDelete(DeleteBehavior.Restrict);  // Evita eliminar en cascada

            modelBuilder.Entity<Movimiento>()
                .HasOne(m => m.Cliente)
                .WithMany()
                .HasForeignKey(m => m.ClienteID)
                .OnDelete(DeleteBehavior.Restrict);

            // Relación: AsistenciasGeneral puede estar asociada a un Cliente o un Usuario
            modelBuilder.Entity<AsistenciaGeneral>()
                .HasOne(a => a.Usuario)
                .WithMany()
                .HasForeignKey(a => a.UsuarioID)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<AsistenciaGeneral>()
                .HasOne(a => a.Cliente)
                .WithMany()
                .HasForeignKey(a => a.ClienteID)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}


