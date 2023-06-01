using Microsoft.EntityFrameworkCore;
using NWS_Api1.Models;


namespace NWS_Api1.Context
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string str = "Server = localhost; Port = 3306; user = root; password = null; Database = NwsEffectif; Integrated Security = True; TrustServerCertificate = True";
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseMySql(str, ServerVersion.AutoDetect(str));
        }

        public DbSet<Nws> nws { get; set; }
    }
}
