using Final_LitchiLearn.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;



namespace Final_LitchiLearn.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Topics> Topics { get; set; }
        public DbSet<Quiz> Quizzes { get; set; }
        public DbSet<Enrol> EnrolTable { get; set; }
        public DbSet<TimeTable> TimeTable { get; set; }



        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {



        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.HasDefaultSchema("Identity");
            builder.Entity<ApplicationUser>(entity =>
            {
                entity.ToTable(name: "User");
            });
            builder.Entity<IdentityRole>(entity =>
            {
                entity.ToTable(name: "Role");
            });
            builder.Entity<IdentityUserRole<string>>(entity =>
            {
                entity.ToTable("UserRoles");
            });
            builder.Entity<IdentityUserClaim<string>>(entity =>
            {
                entity.ToTable("UserClaims");
            });
            builder.Entity<IdentityUserLogin<string>>(entity =>
            {
                entity.ToTable("UserLogins");
            });
            builder.Entity<IdentityRoleClaim<string>>(entity =>
            {
                entity.ToTable("RoleClaims");
            });
            builder.Entity<IdentityUserToken<string>>(entity =>
            {
                entity.ToTable("UserTokens");
            });
            
            
            builder.Entity<UserSubject>()
                .HasKey(us => new { us.UserID, us.SubjectID });

            builder.Entity<UserSubject>()
                .HasOne(us => us.User)
                .WithMany(au => au.UserSubjects)
                .HasForeignKey(us => us.UserID);

            builder.Entity<UserSubject>()
                .HasOne(us => us.Subject)
                .WithMany() 
                .HasForeignKey(us => us.SubjectID);
            // If you add `public ICollection<UserBook> UserBooks { get; set; }`navigation property
            // to Book model class then replace `.WithMany()` with `.WithMany(b => b.UserBooks)`

            
        }
        public DbSet<TimeTable> TimeTable { get; set; }

        public DbSet<Enrol> EnrolTable { get; set; }
    }
}
