using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagementSystem.Infrastructure.Models;

[Table("appointments")]
public partial class Appointment
{
    [Key]
    [Column("appointment_id")]
    public int AppointmentId { get; set; }

    [Column("patient_id")]
    public int? PatientId { get; set; }

    [Column("doctor_id")]
    public int? DoctorId { get; set; }

    [Column("appointment_datetime", TypeName = "timestamp without time zone")]
    public DateTime? AppointmentDatetime { get; set; }

    [Column("appointment_type")]
    [StringLength(50)]
    public string? AppointmentType { get; set; }

    [ForeignKey("DoctorId")]
    [InverseProperty("Appointments")]
    public virtual Doctor? Doctor { get; set; }

    [ForeignKey("PatientId")]
    [InverseProperty("Appointments")]
    public virtual Patient? Patient { get; set; }

    [InverseProperty("Appointment")]
    public virtual ICollection<Token> Tokens { get; set; } = new List<Token>();
}
