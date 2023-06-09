using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using GymAvailabilityApp.Models;
using GymAvailabilityApp.Entities;

namespace GymAvailabilityApp.Data
{
    public class GymAvaiabilityDbContext : IdentityDbContext
    {
        public GymAvaiabilityDbContext(DbContextOptions<GymAvaiabilityDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<IdentityRole>().HasData(new IdentityRole { Name = "User", NormalizedName = "USER", Id = Guid.NewGuid().ToString(), ConcurrencyStamp = Guid.NewGuid().ToString() });
            builder.Entity<IdentityRole>().HasData(new IdentityRole { Name = "Admin", NormalizedName = "ADMIN", Id = Guid.NewGuid().ToString(), ConcurrencyStamp = Guid.NewGuid().ToString() });
            builder.Entity<IdentityRole>().HasData(new IdentityRole { Name = "Employee", NormalizedName = "EMPLOYEE", Id = Guid.NewGuid().ToString(), ConcurrencyStamp = Guid.NewGuid().ToString() });
           

        }

        public DbSet<Machine> Machines { get; set; }
        public DbSet<AvaiabilityReport> AvaiabilityReports { get; set; }
        public DbSet<Gym> Gyms { get; set; }
        public DbSet<GymRoom> GymRooms { get; set; }
        public DbSet<MachinePlacement> MachinePlacements { get; set; }
        public DbSet<AvaiabilityReportFactSt> avaiabilityReportFactSts { get; set; }

    }
}
