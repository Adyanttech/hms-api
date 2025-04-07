using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagementSystem.Infrastructure.Models;

[Table("patients")]
public partial class Patient
{
    [Key]
    [Column("patient_id")]
    public int PatientId { get; set; }

    [Column("patient_name")]
    [StringLength(100)]
    public string PatientName { get; set; } = null!;

    [Column("date_of_birth")]
    public DateOnly? DateOfBirth { get; set; }

    [Column("age")]
    public string? Age { get; set; }

    [Column("gender")]
    [StringLength(10)]
    public string? Gender { get; set; }

    [Column("contact_number")]
    [StringLength(20)]
    public string? ContactNumber { get; set; }

    [Column("address")]
    [StringLength(255)]
    public string? Address { get; set; }

    [Column("guardian_name")]
    [StringLength(100)]
    public string? GuardianName { get; set; }

    [Column("guardian_type")]
    [StringLength(10)]
    public string? GuardianType { get; set; }

    [InverseProperty("Patient")]
    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    [InverseProperty("Patient")]
    public virtual ICollection<Diagnosis> Diagnoses { get; set; } = new List<Diagnosis>();

    [InverseProperty("Patient")]
    public virtual ICollection<Patientmedicine> Patientmedicines { get; set; } = new List<Patientmedicine>();

    [InverseProperty("Patient")]
    public virtual ICollection<Pharmacyinvoice> Pharmacyinvoices { get; set; } = new List<Pharmacyinvoice>();
}
