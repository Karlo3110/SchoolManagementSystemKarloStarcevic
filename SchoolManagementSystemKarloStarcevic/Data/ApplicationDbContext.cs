using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystemKarloStarcevic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagementSystemKarloStarcevic.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<ClassSchedule> ClassSchedules { get; set; }
        public DbSet<Post> Posts { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClassSchedule>()
                .HasOne(cs => cs.Subject)
                .WithMany()
                .HasForeignKey(cs => cs.SubjectId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ClassSchedule>()
                .HasOne(cs => cs.Teacher)
                .WithMany()
                .HasForeignKey(cs => cs.TeacherId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }
    }
}
