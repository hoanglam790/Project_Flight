using FlightDocs.DTO;

namespace FlightDocs.Repository
{
    public interface IDocTypesRepo
    {
        Task<List<DocumentTypeRead>> GetAllDocumentType();
        Task<DocumentTypeRead> GetDocumentTypeById(int id);
        Task<object> CreateDocumentType(DocumentTypeCreate documentTypeCreate);
    }
}
