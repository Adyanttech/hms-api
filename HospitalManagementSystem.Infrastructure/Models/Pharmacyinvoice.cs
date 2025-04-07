using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagementSystem.Infrastructure.Models;

[Table("pharmacyinvoice")]
public partial class Pharmacyinvoice
{
    [Key]
    [Column("invoice_id")]
    public int InvoiceId { get; set; }

    [Column("patient_id")]
    public int PatientId { get; set; }

    [Column("invoice_date")]
    public DateOnly InvoiceDate { get; set; }

    [Column("total_amount")]
    [Precision(10, 2)]
    public decimal TotalAmount { get; set; }

    [Column("created_at", TypeName = "timestamp without time zone")]
    public DateTime? CreatedAt { get; set; }

    [Column("updated_at", TypeName = "timestamp without time zone")]
    public DateTime? UpdatedAt { get; set; }

    [ForeignKey("PatientId")]
    [InverseProperty("Pharmacyinvoices")]
    public virtual Patient Patient { get; set; } = null!;

    [InverseProperty("Invoice")]
    public virtual ICollection<Pharmacyinvoiceitem> Pharmacyinvoiceitems { get; set; } = new List<Pharmacyinvoiceitem>();
}
