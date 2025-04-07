using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagementSystem.Infrastructure.Models;

[Table("medicines")]
public partial class Medicine
{
    [Key]
    [Column("medicine_id")]
    public int MedicineId { get; set; }

    [Column("medicine_name")]
    [StringLength(100)]
    public string MedicineName { get; set; } = null!;

    [Column("chemical_composition")]
    public string? ChemicalComposition { get; set; }

    [Column("manufacturer")]
    [StringLength(100)]
    public string? Manufacturer { get; set; }

    [Column("created_at", TypeName = "timestamp without time zone")]
    public DateTime? CreatedAt { get; set; }

    [Column("updated_at", TypeName = "timestamp without time zone")]
    public DateTime? UpdatedAt { get; set; }

    [InverseProperty("Medicine")]
    public virtual ICollection<Pharmacyinventory> Pharmacyinventories { get; set; } = new List<Pharmacyinventory>();

    [InverseProperty("Medicine")]
    public virtual ICollection<Pharmacyinvoiceitem> Pharmacyinvoiceitems { get; set; } = new List<Pharmacyinvoiceitem>();
}
