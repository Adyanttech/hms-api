using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagementSystem.Infrastructure.Models;

[Table("hospitalregistration")]
[Index("RegistrationNumber", Name = "hospitalregistration_registration_number_key", IsUnique = true)]
public partial class Hospitalregistration
{
    [Key]
    [Column("hospital_id")]
    public int HospitalId { get; set; }

    [Column("hospital_name")]
    [StringLength(255)]
    public string HospitalName { get; set; } = null!;

    [Column("registration_number")]
    [StringLength(50)]
    public string? RegistrationNumber { get; set; }

    [Column("address")]
    [StringLength(255)]
    public string? Address { get; set; }

    [Column("city")]
    [StringLength(100)]
    public string? City { get; set; }

    [Column("state")]
    [StringLength(100)]
    public string? State { get; set; }

    [Column("country")]
    [StringLength(100)]
    public string? Country { get; set; }

    [Column("postal_code")]
    [StringLength(20)]
    public string? PostalCode { get; set; }

    [Column("contact_number")]
    [StringLength(20)]
    public string? ContactNumber { get; set; }

    [Column("email")]
    [StringLength(100)]
    public string? Email { get; set; }

    [Column("website")]
    [StringLength(255)]
    public string? Website { get; set; }

    [Column("registration_date")]
    public DateOnly? RegistrationDate { get; set; }

    [Column("is_main_hospital")]
    public bool? IsMainHospital { get; set; }

    [Column("parent_hospital_id")]
    public int? ParentHospitalId { get; set; }

    [Column("branch_details")]
    [StringLength(255)]
    public string? BranchDetails { get; set; }

    [Column("created_at", TypeName = "timestamp without time zone")]
    public DateTime? CreatedAt { get; set; }

    [Column("updated_at", TypeName = "timestamp without time zone")]
    public DateTime? UpdatedAt { get; set; }

    [InverseProperty("ParentHospital")]
    public virtual ICollection<Hospitalregistration> InverseParentHospital { get; set; } = new List<Hospitalregistration>();

    [ForeignKey("ParentHospitalId")]
    [InverseProperty("InverseParentHospital")]
    public virtual Hospitalregistration? ParentHospital { get; set; }
}
