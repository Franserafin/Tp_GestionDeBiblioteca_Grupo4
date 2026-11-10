using AccesoDatos.Models;
using Microsoft.EntityFrameworkCore;

namespace AccesoDatos.Data
{
    public class AplicationDbContext : DbContext
    {
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Alquiler> Alquileres => Set<Alquiler>();
        public DbSet<Categoria> Categorias => Set<Categoria>();
        public DbSet<Cliente> Clientes => Set<Cliente>();
        public DbSet<Libro> Libros => Set<Libro>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Alquiler>()
                .HasOne(alquiler => alquiler.Cliente)
                .WithMany()
                .HasForeignKey(alquiler => alquiler.ClienteId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Alquiler>()
                .HasOne(alquiler => alquiler.Libro)
                .WithMany(libro => libro.Alquileres)
                .HasForeignKey(alquiler => alquiler.LibroId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
