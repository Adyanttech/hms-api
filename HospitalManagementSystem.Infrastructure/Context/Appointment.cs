using System;
using System.Collections.Generic;

namespace HospitalManagementSystem.Infrastructure.Context;

public partial class Appointment
{
    public int AppointmentId { get; set; }

    public int? PatientId { get; set; }

    public int? DoctorId { get; set; }

    public DateTime? AppointmentDateTime { get; set; }

    public string? AppointmentType { get; set; }

    public virtual Doctor? Doctor { get; set; }

    public virtual ICollection<Token> Tokens { get; set; } = new List<Token>();
}
