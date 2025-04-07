using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagementSystem.Infrastructure.Models;

[Table("diagnosis")]
public partial class Diagnosis
{
    [Key]
    [Column("diagnosis_id")]
    public int DiagnosisId { get; set; }

    [Column("patient_id")]
    public int? PatientId { get; set; }

    [Column("doctor_id")]
    public int? DoctorId { get; set; }

    [Column("diagnosis_date")]
    public DateOnly? DiagnosisDate { get; set; }

    [Column("diagnosis_description")]
    public string? DiagnosisDescription { get; set; }

    [ForeignKey("DoctorId")]
    [InverseProperty("Diagnoses")]
    public virtual Doctor? Doctor { get; set; }

    [ForeignKey("PatientId")]
    [InverseProperty("Diagnoses")]
    public virtual Patient? Patient { get; set; }

    [InverseProperty("Diagnosis")]
    public virtual ICollection<Patientmedicine> Patientmedicines { get; set; } = new List<Patientmedicine>();

    [InverseProperty("Diagnosis")]
    public virtual ICollection<Prescription> Prescriptions { get; set; } = new List<Prescription>();
}
