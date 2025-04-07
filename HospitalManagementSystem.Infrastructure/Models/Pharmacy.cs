using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagementSystem.Infrastructure.Models;

[Table("pharmacy")]
public partial class Pharmacy
{
    [Key]
    [Column("medicine_id")]
    public int MedicineId { get; set; }

    [Column("medicine_name")]
    [StringLength(100)]
    public string MedicineName { get; set; } = null!;

    [Column("manufacturer")]
    [StringLength(100)]
    public string? Manufacturer { get; set; }

    [Column("expiry_date")]
    public DateOnly? ExpiryDate { get; set; }

    [Column("batch_number")]
    [StringLength(50)]
    public string? BatchNumber { get; set; }

    [Column("unit_price")]
    [Precision(10, 2)]
    public decimal? UnitPrice { get; set; }

    [Column("quantity")]
    public int? Quantity { get; set; }

    [Column("description")]
    public string? Description { get; set; }

    [Column("created_at")]
    public DateTime? CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime? UpdatedAt { get; set; }

    [InverseProperty("Medicine")]
    public virtual ICollection<Patientmedicine> Patientmedicines { get; set; } = new List<Patientmedicine>();

    [InverseProperty("Medicine")]
    public virtual ICollection<Prescription> Prescriptions { get; set; } = new List<Prescription>();
}
