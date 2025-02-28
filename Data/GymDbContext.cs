using System.Collections.Generic;
using System.Numerics;
using GymApp.Models;
using Microsoft.EntityFrameworkCore;


namespace GymApp.Data
{
    public class GymDbContext: DbContext
    {
        public GymDbContext(DbContextOptions<GymDbContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        //public DbSet<TipoUsuario> TipoUsuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuración adicional si es necesario
            modelBuilder.Entity<Usuario>()
                .Property(u => u.Activo)
                .HasDefaultValue(true); // Valor predeterminado para el campo 'Activo'

           
        }
    }
}
