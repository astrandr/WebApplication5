using Microsoft.EntityFrameworkCore;
using WebApplication5.Models;

namespace WebApplication5.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<DepartmentEmployee> DepartmentEmployees { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<DepartmentEmployee>(entity =>
            {
                entity.ToTable("DepartmentEmployees");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("ID");
                entity.Property(e => e.Employee).HasMaxLength(25).HasColumnName("Employee");
                entity.Property(e => e.Department).HasMaxLength(25).HasColumnName("Department");
                entity.Property(e => e.Salary).HasColumnType("decimal(18,0)").HasColumnName("Salary");
            });
        }
    }
}
