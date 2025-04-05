using System;
using System.Collections.Generic;

namespace HospitalManagementSystem.Infrastructure.Context;

public partial class Prescription
{
    public int PrescriptionId { get; set; }

    public int? DiagnosisId { get; set; }

    public int? MedicineId { get; set; }

    public int? QuantityPrescribed { get; set; }

    public int? QuantityUsed { get; set; }

    public string? WhenToUsed { get; set; }

    public virtual Diagnosis? Diagnosis { get; set; }

    public virtual Pharmacy? Medicine { get; set; }
}
