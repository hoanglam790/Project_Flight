using FlightDocs.DTO;

namespace FlightDocs.Repository
{
    public class DocumentRepo : IDocumentRepo
    {
        public Task<List<DocumentRead>> GetAllDocument()
        {
            throw new NotImplementedException();
        }

        public Task<DocumentRead> GetDocumentById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CreateDocumentType(DocumentCreate documentCreate)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateDocumentType(DocumentRead documentRead, int id)
        {
            throw new NotImplementedException();
        }
    }
}
