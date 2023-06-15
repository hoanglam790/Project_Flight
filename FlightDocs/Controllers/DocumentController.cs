using FlightDocs.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlightDocs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentController : ControllerBase
    {
        private readonly IDocumentRepo _documentRepo;

        public DocumentController(IDocumentRepo documentRepo)
        {
            _documentRepo = documentRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDocument()
        {
            var getDocument = await _documentRepo.GetAllDocument();
            return Ok(getDocument);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetDocumentById(int id)
        {
            var getDocumentByID = await _documentRepo.GetDocumentById(id);
            if (getDocumentByID != null)
            {
                return Ok(getDocumentByID);
            }
            else
            {
                return BadRequest("Not found document id.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewDocument(DocumentCreate document)
        {
            await _documentRepo.CreateDocumentType(document);
            return Ok("New document has been created successfully");
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateDocument(DocumentCreate document, int id)
        {
            var getDocumentID = await _documentRepo.GetDocumentById(id);
            if (getDocumentID != null)
            {
                await _documentRepo.UpdateDocumentType(document, id);
                return Ok("Document has been updated successfully.");
            }
            else
            {
                return BadRequest("Update fail. Not found document id.");
            }
        }
    }
}
