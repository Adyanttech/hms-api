using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagementSystem.Infrastructure.Models;

[Table("doctors")]
public partial class Doctor
{
    [Key]
    [Column("doctor_id")]
    public int DoctorId { get; set; }

    [Column("doctor_name")]
    [StringLength(100)]
    public string DoctorName { get; set; } = null!;

    [Column("specialization")]
    [StringLength(100)]
    public string? Specialization { get; set; }

    [Column("contact_number")]
    [StringLength(20)]
    public string? ContactNumber { get; set; }

    [Column("email")]
    [StringLength(100)]
    public string? Email { get; set; }

    [Column("address")]
    [StringLength(255)]
    public string? Address { get; set; }

    [Column("department_id")]
    public int? DepartmentId { get; set; }

    [InverseProperty("Doctor")]
    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    [ForeignKey("DepartmentId")]
    [InverseProperty("Doctors")]
    public virtual Department? Department { get; set; }

    [InverseProperty("Doctor")]
    public virtual ICollection<Diagnosis> Diagnoses { get; set; } = new List<Diagnosis>();
}
