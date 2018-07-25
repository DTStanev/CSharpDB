using Microsoft.EntityFrameworkCore;
using Models;

namespace Data
{
    public class EmployeesDBContext : DbContext
    {
        public EmployeesDBContext()
        {
        }

        public EmployeesDBContext(DbContextOptions dbContextOptions)
            : base(dbContextOptions)
        { }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            if (!optionsBuilder.IsConfigured)
            {                
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Employee>(cnfg =>
            {
                cnfg.HasKey(e => e.EmployeeId);

                cnfg.HasOne(e => e.Manager)
                .WithMany(e => e.ManagerEmployees)                
                .HasForeignKey(e => e.ManagerId);
            });

            
        }

    }
}
