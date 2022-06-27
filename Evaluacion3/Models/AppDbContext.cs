using Microsoft.EntityFrameworkCore;

namespace Evaluacion3.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<caracteristicas> tblcaracteristicas { get; set; }
        public DbSet<marca> tblmarcas { get; set; }
        public DbSet<Categoria> tblCategorias { get; set; }
        public DbSet<Tipo> tblTipos { get; set; }
        public DbSet<Clase> tblclases { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration
                .GetConnectionString("DefaultConnection");

            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}