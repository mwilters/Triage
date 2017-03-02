using System;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Triage.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        //Custom Fields to add to AspNetUserTable - testing for Stripe
        public DateTime active_until { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        //Need to add our Domain classes so EF will know about them.  This is for code-first approach
        public DbSet<DIRequest> DiRequests { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<DxCode> DxCodes { get; set; }
        public DbSet<Limitations> Limitations{ get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<PatientRecord> PatientRecords { get; set; }
        public DbSet<Workload> Workloads { get; set; }
        public DbSet<TriageLevel> TriageLevels { get; set; }
        public DbSet<Plan> Plans { get; set; }
        public DbSet<Diagnosis> Diagnosis { get; set; }
        public DbSet<Availability> Availability { get; set; }
        public DbSet<TriageType> TriageType { get; set; }

        public ApplicationDbContext()
            : base("TriageTest", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}