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

        public async Task<object> CreateDocumentType(DocumentTypeCreate documentTypeCreate)
        {
            var r = new Result();
            var documentType = new DocumentType();
            documentType.TyleName = documentTypeCreate.DocumentTypeName;
            documentType.CreateDate = DateTime.Now;
            r.Success = SaveData(documentType);
            return r;
        }

        public bool SaveData(DocumentType documentType)
        {
            _dataContext.Add(documentType);
            _dataContext.SaveChanges();
            return true;
        }
    }
}
