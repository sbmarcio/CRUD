using System.Reflection;
using CRUD.Domain.Entities;
using CRUD.Infrastructure.Data.Mappings;
using Microsoft.EntityFrameworkCore;

namespace CRUD.Infrastructure.Data.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<TipoCliente> TipoClientes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClienteMapping());
            modelBuilder.ApplyConfiguration(new TipoClienteMapping());
        }
    }
}