using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QuantifyBE.Models;

namespace QuantifyBE.Data
{
    public class QuantifyDbContext : IdentityDbContext<AppUser>
    {
        public QuantifyDbContext(DbContextOptions<QuantifyDbContext> options) : base(options)
        {
        }

        DbSet<Food> Foods { get; set; }
        DbSet<Recipe> Recipes { get; set; }

        DbSet<RecipeFood> RecipeFoods { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Food>()
                .HasIndex(f => f.Name).IsUnique();

            modelBuilder.Entity<RecipeFood>()
                .HasKey(rf => new { rf.RecipeId, rf.FoodId });

        }
    }
}
