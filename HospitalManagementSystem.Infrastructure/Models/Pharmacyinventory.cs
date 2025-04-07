using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagementSystem.Infrastructure.Models;

[Table("pharmacyinventory")]
public partial class Pharmacyinventory
{
    [Key]
    [Column("inventory_id")]
    public int InventoryId { get; set; }

    [Column("medicine_id")]
    public int MedicineId { get; set; }

    [Column("batch_number")]
    [StringLength(50)]
    public string BatchNumber { get; set; } = null!;

    [Column("expiry_date")]
    public DateOnly ExpiryDate { get; set; }

    [Column("quantity")]
    public int Quantity { get; set; }

    [Column("unit_price")]
    [Precision(10, 2)]
    public decimal UnitPrice { get; set; }

    [Column("created_at", TypeName = "timestamp without time zone")]
    public DateTime? CreatedAt { get; set; }

    [Column("updated_at", TypeName = "timestamp without time zone")]
    public DateTime? UpdatedAt { get; set; }

    [ForeignKey("MedicineId")]
    [InverseProperty("Pharmacyinventories")]
    public virtual Medicine Medicine { get; set; } = null!;
}
