using Microsoft.EntityFrameworkCore;

namespace WebAPI.Models
{
    public class KapperContext : DbContext
    {
        public KapperContext(DbContextOptions<KapperContext> options) : base(options) { }
        public DbSet<Afspraak> Afspraak { get; set; }
    }
}
