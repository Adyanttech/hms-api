using System;
using System.Collections.Generic;

namespace HospitalManagementSystem.Infrastructure.Context;

public partial class Pharmacy
{
    public int MedicineId { get; set; }

    public string MedicineName { get; set; } = null!;

    public string? Manufacturer { get; set; }

    public DateOnly? ExpiryDate { get; set; }

    public string? BatchNumber { get; set; }

    public decimal? UnitPrice { get; set; }

    public int? Quantity { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<Prescription> Prescriptions { get; set; } = new List<Prescription>();
}
