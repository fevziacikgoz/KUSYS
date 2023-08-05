using KUSYS.Application.Models;
using KUSYS.Domain.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace KUSYS.Infrastructure
{
    public class KUSYSContext : IdentityDbContext<IdentityUser>
    {
        public KUSYSContext(DbContextOptions<KUSYSContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            SeedRoles(builder);
            SeedCourse(builder);
            SeedAdminRoledUser(builder);
            SeedUserRoleAdd(builder);
        }
        private static void SeedRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData(
                  new IdentityRole() { Id = "f6a6d0c9-3b4a-4eb7-8e17-a6da7304f9f9", Name = "Admin", ConcurrencyStamp = "1", NormalizedName = "Admin" },
               new IdentityRole() { Id = "9823e6ee-bb7c-44e2-af1a-574d7dbe1831", Name = "Editor", ConcurrencyStamp = "2", NormalizedName = "Editor" },
               new IdentityRole() { Id = "ee5acbab-1614-4d2b-974b-e40f7da0b1e4", Name = "User", ConcurrencyStamp = "3", NormalizedName = "User" }
               );
        }
        private static void SeedCourse(ModelBuilder builder)
        {
            builder.Entity<Course>().HasData(
               new Course() { Id = 1, Name = "Introduction to Computer Science", Description = "CSI101", IsActive = true },
               new Course() { Id = 2, Name = "Algorithms", Description = "CSI102", IsActive = true },
               new Course() { Id = 3, Name = "Calculus", Description = "MAT101", IsActive = true },
               new Course() { Id = 4, Name = "Physics", Description = "PHY101", IsActive = true }
               );
        }
        private static void SeedAdminRoledUser(ModelBuilder builder)
        {
            IdentityUser user = new IdentityUser()
            {
                Email = "admin@koc.com",
                PhoneNumber = "0500 123 45 67",
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = "admin@koc.com",
                EmailConfirmed = false,
                NormalizedUserName = "admin@koc.com",
                Id = "0fc5dec8-e132-4dca-8262-b28d91c8668b",
                LockoutEnabled=true,
                NormalizedEmail="ADMIN@KOC.COM"
            };
            var ph = new PasswordHasher<IdentityUser>();
            var passhHash = ph.HashPassword(user, "Admin12345.");
            user.PasswordHash = passhHash;
            builder.Entity<IdentityUser>().HasData(user);
        }
        private static void SeedUserRoleAdd(ModelBuilder builder)
        {
            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>() { RoleId = "f6a6d0c9-3b4a-4eb7-8e17-a6da7304f9f9", UserId = "0fc5dec8-e132-4dca-8262-b28d91c8668b" });
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseMatch> CourseMatches { get; set; }
    }
}