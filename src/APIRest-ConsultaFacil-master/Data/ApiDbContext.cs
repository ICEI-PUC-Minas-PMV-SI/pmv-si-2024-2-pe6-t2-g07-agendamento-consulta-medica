using Microsoft.EntityFrameworkCore;
using apirest.Models;

namespace apirest.Data
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
          
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Medico> Medicos { get; set; }

        public DbSet<Consulta> Consultas { get; set; }
    }
}