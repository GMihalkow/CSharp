using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

using P01_HospitalDatabase.Data.Models;

namespace P01_HospitalDatabase.Data
{
    public class HospitalDbContext : DbContext
    {
        public HospitalDbContext()
        {

        }


        public HospitalDbContext(DbContextOptions options)
            : base(options)
        {


        }

        public DbSet<Patient> Patients { get; set; }

        public DbSet<Diagnose> Diagnoses { get; set; }

        public DbSet<Medicament> Medicaments { get; set; }

        public DbSet<PatientMedicament> PatientsMedicaments { get; set; }

        public DbSet<Visitation> Visitations { get; set; }

        public DbSet<Doctor> Doctors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.connectionString);
            }
        }

        //
        // Summary:
        //     Override this method to further configure the model that was discovered by convention
        //     from the entity types exposed in Microsoft.EntityFrameworkCore.DbSet`1 properties
        //     on your derived context. The resulting model may be cached and re-used for subsequent
        //     instances of your derived context.
        //
        // Parameters:
        //   modelBuilder:
        //     The builder being used to construct the model for this context. Databases (and
        //     other extensions) typically define extension methods on this object that allow
        //     you to configure aspects of the model that are specific to a given database.
        //
        // Remarks:
        //     If a model is explicitly set on the options for this context (via Microsoft.EntityFrameworkCore.DbContextOptionsBuilder.UseModel(Microsoft.EntityFrameworkCore.Metadata.IModel))
        //     then this method will not be run.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>()
                .HasKey(p => p.PatientId);

            modelBuilder.Entity<Medicament>()
                .HasKey(m => m.MedicamentId);

            modelBuilder.Entity<PatientMedicament>()
               .HasKey(pm => new { pm.PatientId, pm.MedicamentId });

            modelBuilder.Entity<Diagnose>()
                .HasOne(p => p.Patient)
                .WithMany(d => d.Diagnoses)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Visitation>()
                .HasOne(p => p.Patient)
                .WithMany(v => v.Visitations)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Doctor>()
                .HasMany(v => v.Visitations)
                .WithOne(d => d.Doctor)
                .OnDelete(DeleteBehavior.Restrict);
        }

    }
}
