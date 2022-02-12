using System;
using LeaveAPI.Models;
using LeaveAPI.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace LeaveAPI.Data
{
    public class LeaveContext : DbContext
    {
        private readonly DbSettings settings;
        public DbSet<Leave> Leaves => Set<Leave>();
        public DbSet<LeaveType> LeaveTypes => Set<LeaveType>();

        public LeaveContext(IOptions<DbSettings> settings)
        {
            this.settings = settings.Value;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(settings.ConnectionString);
            optionsBuilder.LogTo(Console.WriteLine);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Leave>(e =>
                {
                    e.ToTable("Permiso");
                    e.HasKey("Id");
                    e.Property("EmployeeFirstName").HasColumnName("NombresEmpleado");
                    e.Property("EmployeeLastName").HasColumnName("ApellidosEmpleado");
                    e.Property("TypeId").HasColumnName("TipoPermiso");
                    e.Property("Date").HasColumnName("FechaPermiso");
                })
                .Entity<LeaveType>(e =>
                {
                    e.ToTable("TipoPermiso");
                    e.HasKey("Id");
                    e.Property("Description").HasColumnName("Descripcion");
                });
        }
    }
}
