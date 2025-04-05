using System;
using System.Collections.Generic;

namespace HospitalManagementSystem.Infrastructure.Context;

public partial class Patient
{
    public int PatientId { get; set; }

    public string PatientName { get; set; } = null!;

    public string PatientFatherName { get; set; } = null!;

    public DateOnly? DateOfBirth { get; set; }

    public string? Gender { get; set; }

    public string? ContactNumber { get; set; }

    public string? Address { get; set; }
}
