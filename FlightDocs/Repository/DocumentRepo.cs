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
            //addDocument.DocumentName = documentCreate.DocumentName;
            addDocument.DocumentTypeID = documentCreate.DocumentTypeID;
            addDocument.CreateDate = DateTime.Now;
            addDocument.Version = "1.0";
            addDocument.FlightID = documentCreate.FlightID;
            addDocument.UserID = documentCreate.UserID;

            if(documentCreate.DocumentName.Length > 0)
            {
                var pathDocument = Path.Combine(Directory.GetCurrentDirectory(), "Upload", "Document", documentCreate.DocumentName.FileName);
                if (!Directory.Exists(pathDocument))
                {
                    Directory.CreateDirectory(pathDocument);
                }
                using(var st = System.IO.File.Create(pathDocument))
                {
                    await documentCreate.DocumentName.CopyToAsync(st);
                    st.Flush();
                }
                addDocument.DocumentName = documentCreate.DocumentName.FileName;
            }
            else
            {
                addDocument.DocumentName = "";
            }
            _dataContext.Documents.Add(addDocument);
            await _dataContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateDocumentType(DocumentCreate document, int id)
        {
            var updateDocument = await _dataContext.Documents.FirstOrDefaultAsync(n => n.DocumentID == id);
            if (updateDocument != null)
            {
                var pathDocument = Path.Combine(Directory.GetCurrentDirectory(), "Upload", "Document", document.DocumentName.FileName);
                if (Directory.Exists(pathDocument))
                {
                    return false;
                }
                else
                {
                    using (var st = System.IO.File.Create(pathDocument))
                    {
                        await document.DocumentName.CopyToAsync(st);
                        st.Flush();
                    }
                    updateDocument.DocumentName = document.DocumentName.FileName;
                }                
                updateDocument.DocumentTypeID = document.DocumentTypeID;
                updateDocument.UpdateDate = DateTime.Now;
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
