using AutoMapper;
using FlightDocs.DTO;

namespace FlightDocs.Profiles
{
    public class CustomProfile : Profile
    {
        public CustomProfile()
        {
            CreateMap<DocumentType, DocumentTypeRead>();
            CreateMap<Flight, FlightRead>();
            CreateMap<Document, DocumentRead>();
        }
    }
}
