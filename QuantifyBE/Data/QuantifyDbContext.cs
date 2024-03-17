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

        public DbSet<Food> Foods { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<RecipeFood> RecipeFoods { get; set; }
        public DbSet<JournalEntry> JournalEntries { get; set; }
        public DbSet<Exercise> Exercises { get; set; }

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

            modelBuilder.Entity<JournalEntry>()
                .HasOne(j => j.Food)
                .WithMany() 
                .HasForeignKey(j => j.FoodId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<JournalEntry>()
                .HasOne(j => j.Recipe)
                .WithMany()
                .HasForeignKey(j => j.RecipeId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<RoutineExerciseDetails>()
                .HasKey(red => new { red.RoutineId, red.ExerciseId });

            modelBuilder.Entity<RoutineExerciseDetails>()
                .HasOne(red => red.Routine)
                .WithMany(r => r.ExerciseDetails)
                .HasForeignKey(red => red.ExerciseId);

            modelBuilder.Entity<RoutineExerciseDetails>()
                .HasOne(red => red.Exercise)
                .WithMany()
                .HasForeignKey(red => red.ExerciseId);

            modelBuilder.Entity<SetDetail>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.HasOne(e => e.RoutineExerciseDetails)
                    .WithMany(red => red.SetDetails)
                    .HasForeignKey(e => new { e.RoutineId, e.ExerciseId });
            });

            modelBuilder.Entity<UserRoutineLogs>()
                .HasOne(url => url.AppUser)
                .WithMany()
                .HasForeignKey(url => url.UserId);
        }
    }
}
