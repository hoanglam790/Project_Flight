using FlightDocs.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlightDocs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentTypeController : ControllerBase
    {
        private readonly IDocTypesRepo _documentTypes;

        public DocumentTypeController(IDocTypesRepo docTypes)
        {
            _documentTypes = docTypes;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDocumentTypes()
        {
            var getAll = await _documentTypes.GetAllDocumentType();
            return Ok(getAll);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetAllDocumentTypesByID(int id)
        {
            var getAll = await _documentTypes.GetDocumentTypeById(id);
            return Ok(getAll);
        }

        [HttpPost]
        public async Task<IActionResult> PostDocumentType(DocumentTypeCreate newDocumentType)
        {
            await _documentTypes.CreateDocumentType(newDocumentType);
            return Ok("New document type has been created successfully.");
        }
    }
}
