using Crayons.Domain.DataAccess.Configurations;
using Crayons.Domain.Entities;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;

namespace Crayons.Domain.DataAccess
{
    public class CrayonsDbContext : DbContext
    {
        public CrayonsDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Recipe> Recipies { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new RecipeConfiguration());
        }
    }
}