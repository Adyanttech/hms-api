using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagementSystem.Infrastructure.Models;

[Table("pharmacyinvoiceitems")]
public partial class Pharmacyinvoiceitem
{
    [Key]
    [Column("invoice_item_id")]
    public int InvoiceItemId { get; set; }

    [Column("invoice_id")]
    public int InvoiceId { get; set; }

    [Column("medicine_id")]
    public int MedicineId { get; set; }

    [Column("quantity")]
    public int Quantity { get; set; }

    [Column("unit_price")]
    [Precision(10, 2)]
    public decimal UnitPrice { get; set; }

    [Column("total_price")]
    [Precision(10, 2)]
    public decimal TotalPrice { get; set; }

    [Column("created_at", TypeName = "timestamp without time zone")]
    public DateTime? CreatedAt { get; set; }

    [Column("updated_at", TypeName = "timestamp without time zone")]
    public DateTime? UpdatedAt { get; set; }

    [ForeignKey("InvoiceId")]
    [InverseProperty("Pharmacyinvoiceitems")]
    public virtual Pharmacyinvoice Invoice { get; set; } = null!;

    [ForeignKey("MedicineId")]
    [InverseProperty("Pharmacyinvoiceitems")]
    public virtual Medicine Medicine { get; set; } = null!;
}
