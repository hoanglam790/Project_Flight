using AutoMapper;
using FlightDocs.DTO;

namespace FlightDocs.Repository
{
    public class DocumentRepo : IDocumentRepo
    {
        private readonly FlightDocsContext _context;
        private readonly IMapper _mapper;

        public DocumentRepo (FlightDocsContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<DocumentRead>> GetAllDocument()
        {
            var listDocument = await _context.Documents.ToListAsync();
            return _mapper.Map<List<DocumentRead>>(listDocument);
        }

        public async Task<DocumentRead> GetDocumentById(int id)
        {
            var listDocumentByID = await _context.Documents.FindAsync(id);
            return _mapper.Map<DocumentRead>(listDocumentByID);
        }

        public async Task<bool> CreateDocumentType(DocumentCreate documentCreate)
        {
            var addDocument = new Document();
            addDocument.DocumentName = documentCreate.DocumentName;
            addDocument.TypeId = documentCreate.DocumentTypeID;
            addDocument.CreateDate = DateTime.Now;
            addDocument.Version = "1.0";
            addDocument.Note = documentCreate.Note;
            addDocument.FlightId = documentCreate.FlightID;
            addDocument.UserId = documentCreate.UserID;
            _context.Documents.Add(addDocument);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateDocumentType(DocumentCreate document, int id)
        {
            var updateDocument = await _context.Documents.FirstOrDefaultAsync(n => n.DocumentId == id);
            if(updateDocument != null)
            {
                updateDocument.DocumentName = document.DocumentName;
                updateDocument.TypeId = document.DocumentTypeID;
                updateDocument.CreateDate = DateTime.Now;
                updateDocument.Version = "1.1";
                updateDocument.Note = document.Note;
                updateDocument.FlightId = document.FlightID;
                updateDocument.UserId = document.UserID;
                _context.Update(updateDocument);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
