using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalManagementSystem.Application.Interfaces;
using HospitalManagementSystem.Core.Entities;

namespace HospitalManagementSystem.Application.Services
{
    public class DocumentService : IDocumentService
    {
        public Task<byte[]> GenerateInvoicePdfAsync(InvoiceModel invoice)
        {
            throw new NotImplementedException();
        }

        public Task<byte[]> GeneratePrescriptionPdfAsync(PrescriptionModel prescription)
        {
            throw new NotImplementedException();
        }
    }
}
