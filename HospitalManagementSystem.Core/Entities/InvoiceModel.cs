using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Core.Entities
{
    public class InvoiceModel
    {
        public string? InvoiceNumber { get; set; }
        public DateTime Date { get; set; }
        public string? PatientName { get; set; }
        public string? InvoiceDetails { get; set; }
        public decimal Amount { get; set; }
    }
}
