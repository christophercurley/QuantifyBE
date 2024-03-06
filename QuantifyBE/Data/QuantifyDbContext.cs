using Microsoft.EntityFrameworkCore;
using QuantifyBE.Models;

namespace QuantifyBE.Data
{
    public class QuantifyDbContext : DbContext
    {
        public QuantifyDbContext(DbContextOptions<QuantifyDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Food>()
                .HasIndex(f => f.Name).IsUnique();
        }
    }
}
