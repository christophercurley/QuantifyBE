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
        DbSet<JournalEntry> JournalEntries { get; set; }
        DbSet<Exercise> Exercises { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Food>()
                .HasIndex(f => f.Name).IsUnique();

            modelBuilder.Entity<RecipeFood>()
                .HasKey(rf => new { rf.RecipeId, rf.FoodId });

            modelBuilder.Entity<JournalEntry>()
            .HasOne(j => j.AppUser)
            .WithMany()
            .HasForeignKey(j => j.UserId);

            modelBuilder.Entity<RoutineExerciseDetails>()
                .HasKey(red => new { red.RoutineId, red.ExerciseId });

            modelBuilder.Entity<RoutineExerciseDetails>()
                .HasOne(red => red.Routine)
                .WithMany(red => red.ExerciseDetails)
                .HasForeignKey(red => red.ExerciseId);

            modelBuilder.Entity<RoutineExerciseDetails>()
                .HasOne(red => red.Exercise)
                .WithMany()
                .HasForeignKey(red => red.ExerciseId);

            modelBuilder.Entity<SetDetail>(entity =>
            {
                entity.HasKey(e => new { e.RoutineExerciseDetailId, e.SetNumber });

                entity.HasOne(e => e.RoutineExerciseDetails)
                    .WithMany(d => d.SetDetails)
                    .HasForeignKey(e => e.RoutineExerciseDetailId);
            });
        }
    }
}
