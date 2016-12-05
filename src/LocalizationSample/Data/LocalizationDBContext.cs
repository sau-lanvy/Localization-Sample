using LocalizationSample.Models;
using Microsoft.EntityFrameworkCore;

namespace LocalizationSample.Data
{
    public class LocalizationDBContext : DbContext
    {
        public DbSet<Culture> Cultures { get; set; }
        public DbSet<Resource> Resources { get; set; }

        public LocalizationDBContext(DbContextOptions<LocalizationDBContext> options) : base(options)
        { }
    }
}
