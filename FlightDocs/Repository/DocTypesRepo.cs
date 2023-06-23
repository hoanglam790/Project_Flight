using AutoMapper;
using FlightDocs.DTO;
using FlightDocs.Results;

namespace FlightDocs.Repository
{
    public class DocTypesRepo : IDocTypesRepo
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;

        public DocTypesRepo(DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<List<DocumentTypeRead>> GetAllDocumentType()
        {
            var getDocumentType = await _dataContext.DocumentTypes.ToListAsync();
            return _mapper.Map<List<DocumentTypeRead>>(getDocumentType);
        }

        public async Task<DocumentTypeRead> GetDocumentTypeById(int id)
        {
            var getDocumentTypeByID = await _dataContext.DocumentTypes.FindAsync(id);
            return _mapper.Map<DocumentTypeRead>(getDocumentTypeByID);
        }

        public async Task<bool> CreateDocumentType(DocumentTypeCreate documentTypeCreate)
        {
            var documentType = new DocumentType();
            documentType.TyleName = documentTypeCreate.DocumentTypeName;
            documentType.CreateDate = DateTime.Now;
            _dataContext.DocumentTypes.Add(documentType);
            await _dataContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateDocumentType(DocumentTypeRead documentTypeRead, int id)
        {
            //var updateDocsType = await _dataContext.DocumentTypes.FirstOrDefaultAsync(n => n.TypeID == id);
            //if (updateDocsType != null)
            //{
            //    updateDocsType.TyleName = documentTypeRead.DocumentTypeName;
            //    updateDocsType.CreateDate = DateTime.Now;
            //    _dataContext.Update(updateDocsType);
            //    await _dataContext.SaveChangesAsync();
            //    return true;
            //}
            //else
            //{
                return false;
            //}
        }

        public async Task<bool> DeleteDocumentType(int id)
        {
            //var deleteDocsType = await _dataContext.DocumentTypes.FirstOrDefaultAsync(n => n.TypeID == id);
            //if (deleteDocsType != null)
            //{
            //    _dataContext.Remove(deleteDocsType);
            //    await _dataContext.SaveChangesAsync();
            //    return true;
            //}
            //else
            //{
                return false;
            //}
        }
    }
}
