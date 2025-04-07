using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagementSystem.Infrastructure.Models;

[Table("prescription")]
public partial class Prescription
{
    [Key]
    [Column("prescription_id")]
    public int PrescriptionId { get; set; }

    [Column("diagnosis_id")]
    public int? DiagnosisId { get; set; }

    [Column("medicine_id")]
    public int? MedicineId { get; set; }

    [Column("quantity_prescribed")]
    public int? QuantityPrescribed { get; set; }

    [Column("quantity_used")]
    public int? QuantityUsed { get; set; }

    [Column("morning")]
    public bool? Morning { get; set; }

    [Column("afternoon")]
    public bool? Afternoon { get; set; }

    [Column("night")]
    public bool? Night { get; set; }

    [Column("before_food")]
    public bool? BeforeFood { get; set; }

    [Column("after_food")]
    public bool? AfterFood { get; set; }

    [Column("created_at")]
    public DateTime? CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime? UpdatedAt { get; set; }

    [ForeignKey("DiagnosisId")]
    [InverseProperty("Prescriptions")]
    public virtual Diagnosis? Diagnosis { get; set; }

    [ForeignKey("MedicineId")]
    [InverseProperty("Prescriptions")]
    public virtual Pharmacy? Medicine { get; set; }
}
