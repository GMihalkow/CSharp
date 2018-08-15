using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

using P01_StudentSystem.Data.Models;

namespace P01_StudentSystem.Data
{
    public class StudentSystemContext : DbContext
    {
        public StudentSystemContext()
        {

        }

        public StudentSystemContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<Student> Students { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Resource> Resources { get; set; }

        public DbSet<Homework> HomeworkSubmissions { get; set; }

        public DbSet<StudentCourse> StudentCourses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Student
            modelBuilder.Entity<Student>()
                .Property(s => s.PhoneNumber)
                .HasColumnType("char(10)");

            ////Resource
            //modelBuilder.Entity<Resource>()
            //    .HasOne(r => r.Course)
            //    .WithMany(c => c.HomeworkSubmissions)
            //    .HasForeignKey(r => r.CourseId);

            //Homework
            modelBuilder.Entity<Homework>()
                .HasOne(h => h.Student)
                .WithMany(s => s.HomeworkSubmissions)
                .HasForeignKey(h => h.StudentId);

            modelBuilder.Entity<Homework>()
                .HasOne(h => h.Course)
                .WithMany(c => c.HomeworkSubmissions)
                .HasForeignKey(h => h.CourseId);

            //StudentCourse
            modelBuilder.Entity<StudentCourse>()
                .HasKey(sc => new { sc.StudentId, sc.CourseId });

            modelBuilder.Entity<Student>()
                .HasMany(s => s.CourseEnrollments)
                .WithOne(sc => sc.Student)
                .HasForeignKey(sc => sc.StudentId);

            modelBuilder.Entity<Course>()
                .HasMany(c => c.StudentsEnrolled)
                .WithOne(sc => sc.Course)
                .HasForeignKey(sc => sc.CourseId);

            //Courses
            modelBuilder.Entity<Course>()
                .HasMany(c => c.Resources)
                .WithOne(r => r.Course)
                .HasForeignKey(r => r.CourseId);

            modelBuilder.Entity<Course>()
                .HasMany(c => c.HomeworkSubmissions)
                .WithOne(h => h.Course)
                .HasForeignKey(h => h.CourseId);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
        }
    }
}
