using AutoMapper;
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
            var getDocumentTypeID = await _documentTypes.GetDocumentTypeById(id);
            if(getDocumentTypeID != null)
            {
                return Ok(getDocumentTypeID);
            }
            else
            {
                return BadRequest("Not found document type id.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostDocumentType(DocumentTypeCreate newDocumentType)
        {
            await _documentTypes.CreateDocumentType(newDocumentType);
            return Ok("New document type has been created successfully.");
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateDocumentTypes(DocumentTypeRead documentTypeRead, int id)
        {
            var updateDocumentTypeID = await _documentTypes.GetDocumentTypeById(id);
            if(updateDocumentTypeID != null)
            {
                await _documentTypes.UpdateDocumentType(documentTypeRead, id);
                return Ok("Document type has been updated successfully.");
            }
            else
            {
                return BadRequest("Update fail. Not found document type id.");
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteDocumentTypes(int id)
        {
            var updateDocumentTypeID = await _documentTypes.GetDocumentTypeById(id);
            if (updateDocumentTypeID != null)
            {
                await _documentTypes.DeleteDocumentType(id);
                return Ok("Document type has been deleted successfully.");
            }
            else
            {
                return BadRequest("Delete fail. Not found document type id.");
            }
        }
    }
}
