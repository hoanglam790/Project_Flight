using FlightDocs.DTO;

namespace FlightDocs.Repository
{
    public interface IDocumentRepo
    {
        Task<List<DocumentRead>> GetAllDocument();
        Task<DocumentRead> GetDocumentById(int id);
        Task<bool> CreateDocumentType(DocumentCreate documentCreate);
        Task<bool> UpdateDocumentType(DocumentRead documentRead, int id);
    }
}
