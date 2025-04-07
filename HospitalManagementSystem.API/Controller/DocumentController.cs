using HospitalManagementSystem.Application.Interfaces;
using HospitalManagementSystem.Core.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HospitalManagementSystem.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentController : ControllerBase
    {
        private readonly IDocumentService _documentService;

        public DocumentController(IDocumentService document) 
        { 
            _documentService = document;
        }

        //// GET: api/<DocumentController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/<DocumentController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        [HttpPost("invoice")]
        public async Task<IActionResult> Post([FromBody] InvoiceModel model)
        {
            var pdfBytes = await _documentService.GenerateInvoicePdfAsync(model);
            return File(pdfBytes, "application/pdf", "invoice.pdf");
        }

        [HttpPost("prescription")]
        public async Task<IActionResult> Post([FromBody] PrescriptionModel model)
        {
            var pdfBytes = await _documentService.GeneratePrescriptionPdfAsync(model);
            return File(pdfBytes, "application/pdf", "prescription.pdf");
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
