using System;
using System.Collections.Generic;

namespace HospitalManagementSystem.Infrastructure.Context;

public partial class Diagnosis
{
    public int DiagnosisId { get; set; }

    public int? PatientId { get; set; }

    public int? DoctorId { get; set; }

    public DateOnly? DiagnosisDate { get; set; }

    public string? DiagnosisDescription { get; set; }

    public virtual Doctor? Doctor { get; set; }

    public virtual ICollection<Prescription> Prescriptions { get; set; } = new List<Prescription>();
}
