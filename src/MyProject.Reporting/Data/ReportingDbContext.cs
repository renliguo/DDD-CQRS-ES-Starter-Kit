using Microsoft.EntityFrameworkCore;
using MyProject.Reporting.Data.Entities;

namespace MyProject.Reporting.Data
{
    public class ReportingDbContext : DbContext
    {
        public ReportingDbContext(DbContextOptions<ReportingDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ProductEntity>()
                .ToTable("Product");
        }

        public DbSet<ProductEntity> Products { get; set; }
    }
}
