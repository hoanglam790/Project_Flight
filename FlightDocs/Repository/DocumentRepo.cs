using AutoMapper;
using FlightDocs.DTO;

namespace FlightDocs.Repository
{
    public class DocumentRepo : IDocumentRepo
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;

        public DocumentRepo(DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<List<DocumentRead>> GetAllDocument()
        {
            var listDocument = await _dataContext.Documents.ToListAsync();
            return _mapper.Map<List<DocumentRead>>(listDocument);
        }

        public async Task<DocumentRead> GetDocumentById(int id)
        {
            var listDocumentByID = await _dataContext.Documents.FindAsync(id);
            return _mapper.Map<DocumentRead>(listDocumentByID);
        }
        public async Task<bool> CreateDocumentType(DocumentCreate documentCreate)
        {
            var addDocument = new Document();
            addDocument.DocumentName = documentCreate.DocumentName;
            addDocument.TypeID = documentCreate.DocumentTypeID;
            addDocument.CreateDate = DateTime.Now;
            addDocument.Version = "1.0";
            addDocument.FlightID = documentCreate.FlightID;
            addDocument.UserID = documentCreate.UserID;
            _dataContext.Documents.Add(addDocument);
            await _dataContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateDocumentType(DocumentCreate document, int id)
        {
            var updateDocument = await _dataContext.Documents.FirstOrDefaultAsync(n => n.DocumentID == id);
            if (updateDocument != null)
            {
                updateDocument.DocumentName = document.DocumentName;
                updateDocument.TypeID = document.DocumentTypeID;
                updateDocument.CreateDate = DateTime.Now;
                updateDocument.Version = "1.1";
                updateDocument.FlightID = document.FlightID;
                updateDocument.UserID = document.UserID;
                _dataContext.Update(updateDocument);
                await _dataContext.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
