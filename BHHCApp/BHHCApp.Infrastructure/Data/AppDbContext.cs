using BHHCApp.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BHHCApp.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) 
            : base(options)
        {
        }

        public DbSet<Reason> Reasons { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Reason>(ConfigureReason);
            builder.Entity<Reason>().HasData(new Reason { id = 1, description = "Skills contribution to company success" });
            builder.Entity<Reason>().HasData(new Reason { id = 2, description = "Company great reputation" });
            builder.Entity<Reason>().HasData(new Reason { id = 3, description = "Work culture and passion for technologies" });
        }

        private void ConfigureReason(EntityTypeBuilder<Reason> builder)
        {
            builder.HasKey(ci => ci.id);
            builder.Property(cb => cb.description)
                .IsRequired()
                .HasMaxLength(300);
            builder.ToTable("Reason");
        }
    }
}
