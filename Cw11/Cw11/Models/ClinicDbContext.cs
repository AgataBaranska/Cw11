using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cw11.Models
{
    public class ClinicDbContext:DbContext  
    {
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }

        public DbSet<Medicament> Medicaments { get; set; }
        public DbSet<Patient> Patients { get; set; }

        public DbSet<Prescription_Medicament> Prescription_Medicaments { get; set; }
        public ClinicDbContext()
        {

        }

        public ClinicDbContext(DbContextOptions options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
           var doctors = new List<Doctor>();
            doctors.Add(new Doctor { IdDoctor = 1, FirstName = "Bogdan", LastName = "Banachowski", Email = "bbanachowski@fajnylekarz.pl" });
            doctors.Add(new Doctor { IdDoctor = 2, FirstName = "Zuzanna", LastName = "Mądra", Email = "zmadra@fajnylekarz.pl" });

            modelBuilder.Entity<Doctor>()
                .HasData(doctors);

            var patients = new List<Patient>();
            patients.Add(new Patient { IdPatient = 1, FirstName = "Ziemowit", LastName = "Chorowity", Birthdate = new DateTime(1993,2,21)});
            patients.Add(new Patient { IdPatient = 2, FirstName = "Ola", LastName = "Zasmarkana", Birthdate = new DateTime(1996, 3, 13) });
            modelBuilder.Entity<Patient>()
                .HasData(patients);

            var medicaments = new List<Medicament>();
            medicaments.Add(new Medicament { IdMedicament = 1, Name = "Polopityna", Description = "Na gorączkę", Type = "lekki" });

            medicaments.Add(new Medicament { IdMedicament = 2, Name = "ApapForte", Description = "Na ból", Type = "silny" });

            modelBuilder.Entity<Medicament>()
                        .HasData(medicaments);

            var prescriptions = new List<Prescription>();
            prescriptions.Add(new Prescription { IdPrescription = 1, Date = new DateTime(2020,10,21), DueDate = new DateTime(2020, 12, 21), Doctor = null, Patient = null });

            prescriptions.Add(new Prescription { IdPrescription = 2, Date = new DateTime(2021,01, 11), DueDate = new DateTime(2021, 02, 11), Doctor = null, Patient = null });

            modelBuilder.Entity<Prescription>()
                        .HasData(prescriptions);


            var prescriptionMedicaments = new List<Prescription_Medicament>();
            prescriptionMedicaments.Add(new Prescription_Medicament { IdMedicament = 1, IdPrescription = 1, Dose = 1, Details = "20mg"});

            prescriptionMedicaments.Add(new Prescription_Medicament { IdMedicament = 2, IdPrescription = 2, Dose = 2, Details = "10mg"});

            modelBuilder.Entity<Prescription_Medicament>()
                        .HasData(prescriptionMedicaments);




        }
    }
}
