using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagementSystem.Infrastructure.Models;

public partial class HmsDbContext : DbContext
{
    public HmsDbContext()
    {
    }

    public HmsDbContext(DbContextOptions<HmsDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Appointment> Appointments { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Diagnosis> Diagnoses { get; set; }

    public virtual DbSet<Doctor> Doctors { get; set; }

    public virtual DbSet<Hospitalregistration> Hospitalregistrations { get; set; }

    public virtual DbSet<Medicine> Medicines { get; set; }

    public virtual DbSet<Patient> Patients { get; set; }

    public virtual DbSet<Patientmedicine> Patientmedicines { get; set; }

    public virtual DbSet<Pharmacy> Pharmacies { get; set; }

    public virtual DbSet<Pharmacyinventory> Pharmacyinventories { get; set; }

    public virtual DbSet<Pharmacyinvoice> Pharmacyinvoices { get; set; }

    public virtual DbSet<Pharmacyinvoiceitem> Pharmacyinvoiceitems { get; set; }

    public virtual DbSet<Prescription> Prescriptions { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Token> Tokens { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Name=SupabaseConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasPostgresEnum("auth", "aal_level", new[] { "aal1", "aal2", "aal3" })
            .HasPostgresEnum("auth", "code_challenge_method", new[] { "s256", "plain" })
            .HasPostgresEnum("auth", "factor_status", new[] { "unverified", "verified" })
            .HasPostgresEnum("auth", "factor_type", new[] { "totp", "webauthn", "phone" })
            .HasPostgresEnum("auth", "one_time_token_type", new[] { "confirmation_token", "reauthentication_token", "recovery_token", "email_change_token_new", "email_change_token_current", "phone_change_token" })
            .HasPostgresEnum("pgsodium", "key_status", new[] { "default", "valid", "invalid", "expired" })
            .HasPostgresEnum("pgsodium", "key_type", new[] { "aead-ietf", "aead-det", "hmacsha512", "hmacsha256", "auth", "shorthash", "generichash", "kdf", "secretbox", "secretstream", "stream_xchacha20" })
            .HasPostgresEnum("realtime", "action", new[] { "INSERT", "UPDATE", "DELETE", "TRUNCATE", "ERROR" })
            .HasPostgresEnum("realtime", "equality_op", new[] { "eq", "neq", "lt", "lte", "gt", "gte", "in" })
            .HasPostgresExtension("extensions", "pg_stat_statements")
            .HasPostgresExtension("extensions", "pgcrypto")
            .HasPostgresExtension("extensions", "pgjwt")
            .HasPostgresExtension("extensions", "uuid-ossp")
            .HasPostgresExtension("graphql", "pg_graphql")
            .HasPostgresExtension("pgsodium", "pgsodium")
            .HasPostgresExtension("vault", "supabase_vault");

        modelBuilder.Entity<Appointment>(entity =>
        {
            entity.HasKey(e => e.AppointmentId).HasName("appointments_pkey");

            entity.HasOne(d => d.Doctor).WithMany(p => p.Appointments).HasConstraintName("appointments_doctor_id_fkey");

            entity.HasOne(d => d.Patient).WithMany(p => p.Appointments).HasConstraintName("appointments_patient_id_fkey");
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.DepartmentId).HasName("departments_pkey");
        });

        modelBuilder.Entity<Diagnosis>(entity =>
        {
            entity.HasKey(e => e.DiagnosisId).HasName("diagnosis_pkey");

            entity.HasOne(d => d.Doctor).WithMany(p => p.Diagnoses).HasConstraintName("diagnosis_doctor_id_fkey");

            entity.HasOne(d => d.Patient).WithMany(p => p.Diagnoses).HasConstraintName("diagnosis_patient_id_fkey");
        });

        modelBuilder.Entity<Doctor>(entity =>
        {
            entity.HasKey(e => e.DoctorId).HasName("doctors_pkey");

            entity.HasOne(d => d.Department).WithMany(p => p.Doctors).HasConstraintName("doctors_department_id_fkey");
        });

        modelBuilder.Entity<Hospitalregistration>(entity =>
        {
            entity.HasKey(e => e.HospitalId).HasName("hospitalregistration_pkey");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
            entity.Property(e => e.IsMainHospital).HasDefaultValue(true);
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");

            entity.HasOne(d => d.ParentHospital).WithMany(p => p.InverseParentHospital).HasConstraintName("hospitalregistration_parent_hospital_id_fkey");
        });

        modelBuilder.Entity<Medicine>(entity =>
        {
            entity.HasKey(e => e.MedicineId).HasName("medicines_pkey");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
        });

        modelBuilder.Entity<Patient>(entity =>
        {
            entity.HasKey(e => e.PatientId).HasName("patients_pkey");
        });

        modelBuilder.Entity<Patientmedicine>(entity =>
        {
            entity.HasKey(e => e.PatientMedicineId).HasName("patientmedicine_pkey");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("now()");

            entity.HasOne(d => d.Diagnosis).WithMany(p => p.Patientmedicines).HasConstraintName("patientmedicine_diagnosis_id_fkey");

            entity.HasOne(d => d.Medicine).WithMany(p => p.Patientmedicines).HasConstraintName("patientmedicine_medicine_id_fkey");

            entity.HasOne(d => d.Patient).WithMany(p => p.Patientmedicines).HasConstraintName("patientmedicine_patient_id_fkey");
        });

        modelBuilder.Entity<Pharmacy>(entity =>
        {
            entity.HasKey(e => e.MedicineId).HasName("pharmacy_pkey");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("now()");
        });

        modelBuilder.Entity<Pharmacyinventory>(entity =>
        {
            entity.HasKey(e => e.InventoryId).HasName("pharmacyinventory_pkey");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");

            entity.HasOne(d => d.Medicine).WithMany(p => p.Pharmacyinventories).HasConstraintName("pharmacyinventory_medicine_id_fkey");
        });

        modelBuilder.Entity<Pharmacyinvoice>(entity =>
        {
            entity.HasKey(e => e.InvoiceId).HasName("pharmacyinvoice_pkey");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");

            entity.HasOne(d => d.Patient).WithMany(p => p.Pharmacyinvoices).HasConstraintName("pharmacyinvoice_patient_id_fkey");
        });

        modelBuilder.Entity<Pharmacyinvoiceitem>(entity =>
        {
            entity.HasKey(e => e.InvoiceItemId).HasName("pharmacyinvoiceitems_pkey");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");

            entity.HasOne(d => d.Invoice).WithMany(p => p.Pharmacyinvoiceitems).HasConstraintName("pharmacyinvoiceitems_invoice_id_fkey");

            entity.HasOne(d => d.Medicine).WithMany(p => p.Pharmacyinvoiceitems).HasConstraintName("pharmacyinvoiceitems_medicine_id_fkey");
        });

        modelBuilder.Entity<Prescription>(entity =>
        {
            entity.HasKey(e => e.PrescriptionId).HasName("prescription_pkey");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("now()");

            entity.HasOne(d => d.Diagnosis).WithMany(p => p.Prescriptions).HasConstraintName("prescription_diagnosis_id_fkey");

            entity.HasOne(d => d.Medicine).WithMany(p => p.Prescriptions).HasConstraintName("prescription_medicine_id_fkey");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("roles_pkey");

            entity.Property(e => e.Id).HasDefaultValueSql("gen_random_uuid()");
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("now()");
        });

        modelBuilder.Entity<Token>(entity =>
        {
            entity.HasKey(e => e.Tokenid).HasName("tokens_pkey");

            entity.Property(e => e.Generatedat).HasDefaultValueSql("CURRENT_TIMESTAMP");
            entity.Property(e => e.Isserved).HasDefaultValue(false);

            entity.HasOne(d => d.Appointment).WithMany(p => p.Tokens)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tokens_appointmentid_fkey");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("users_pkey");

            entity.Property(e => e.Id).HasDefaultValueSql("gen_random_uuid()");
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("now()");

            entity.HasOne(d => d.Hospital).WithMany(p => p.Users).HasConstraintName("fk_users_hospital");

            entity.HasOne(d => d.Role).WithMany(p => p.Users).HasConstraintName("fk_users_role");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
