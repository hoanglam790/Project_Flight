using FlightDocs.DTO;

namespace FlightDocs.Repository
{
    public interface IDocTypesRepo
    {
        Task<List<DocumentTypeRead>> GetAllDocumentType();
        Task<DocumentTypeRead> GetDocumentTypeById(int id);
        Task<bool> CreateDocumentType(DocumentTypeCreate documentTypeCreate);
        Task<bool> UpdateDocumentType(DocumentTypeRead documentTypeRead, int id);
        Task<bool> DeleteDocumentType(int id);
    }
}
