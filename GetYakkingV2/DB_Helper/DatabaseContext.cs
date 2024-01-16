using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace GetYakkingV2.DB_Helper
{
    public class DatabaseContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public DatabaseContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = _configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connectionString);
        }

        // Define DB sets for your entities, e.g., Players
        // public DbSet<Player> Players { get; set; }
    }
}
