using MealPlannerApp.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealPlannerApp.DbContexts
{
    public class MealPlannerAppDbContext :DbContext
    {
        public DbSet<IngredientDTO> Ingredients { get; set; }
        public DbSet<RecipeDTO> Recipes { get; set; }
        public DbSet<RecipeIngredientDTO> RecipeIngredients { get; set; }
        public DbSet<StepDTO> Steps { get; set; }
        public MealPlannerAppDbContext(DbContextOptions<MealPlannerAppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Ingredient: ensure unique name to allow lookup for shared ingredients
            modelBuilder.Entity<IngredientDTO>()
                .HasIndex(i => i.Name)
                .IsUnique();

            // RecipeIngredient: composite key to prevent duplicate pairs
            modelBuilder.Entity<RecipeIngredientDTO>()
                .HasKey(ri => new { ri.RecipeId, ri.IngredientId });

            modelBuilder.Entity<RecipeIngredientDTO>()
                .HasOne(ri => ri.Recipe)
                .WithMany(r => r.RecipeIngredients)
                .HasForeignKey(ri => ri.RecipeId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<RecipeIngredientDTO>()
                .HasOne(ri => ri.Ingredient)
                .WithMany(i => i.RecipeIngredients)
                .HasForeignKey(ri => ri.IngredientId)
                .OnDelete(DeleteBehavior.Restrict);

            // Step: ensure ordering is unique per recipe
            modelBuilder.Entity<StepDTO>()
                .HasIndex(s => new { s.RecipeId, s.Order })
                .IsUnique();
        }
    }

}
}
