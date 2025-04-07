using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagementSystem.Infrastructure.Models;

[Table("patientmedicine")]
public partial class Patientmedicine
{
    [Key]
    [Column("patient_medicine_id")]
    public int PatientMedicineId { get; set; }

    [Column("patient_id")]
    public int? PatientId { get; set; }

    [Column("diagnosis_id")]
    public int? DiagnosisId { get; set; }

    [Column("medicine_id")]
    public int? MedicineId { get; set; }

    [Column("quantity")]
    public int? Quantity { get; set; }

    [Column("created_at")]
    public DateTime? CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime? UpdatedAt { get; set; }

    [ForeignKey("DiagnosisId")]
    [InverseProperty("Patientmedicines")]
    public virtual Diagnosis? Diagnosis { get; set; }

    [ForeignKey("MedicineId")]
    [InverseProperty("Patientmedicines")]
    public virtual Pharmacy? Medicine { get; set; }

    [ForeignKey("PatientId")]
    [InverseProperty("Patientmedicines")]
    public virtual Patient? Patient { get; set; }
}
