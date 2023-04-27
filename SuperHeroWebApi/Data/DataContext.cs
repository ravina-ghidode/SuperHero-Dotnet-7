using Microsoft.EntityFrameworkCore;

namespace SuperHeroWebApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext>options):base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=.\\SqlExpress; Database=SuperHeroDatabase; Trusted_Connection = true; TrustServerCertificate= true;");
        }
        public DbSet<SuperHero> SuperHeroes { get; set; }

    }
}
