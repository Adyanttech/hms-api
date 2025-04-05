using System;
using System.Collections.Generic;

namespace HospitalManagementSystem.Infrastructure.Context;

public partial class Token
{
    public int TokenId { get; set; }

    public int AppointmentId { get; set; }

    public int TokenNumber { get; set; }

    public bool IsServed { get; set; }

    public DateTime GeneratedAt { get; set; }

    public DateTime? ServedAt { get; set; }

    public virtual Appointment Appointment { get; set; } = null!;
}
