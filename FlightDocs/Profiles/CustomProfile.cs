using AutoMapper;
using FlightDocs.DTO;

namespace FlightDocs.Profiles
{
    public class CustomProfile : Profile
    {
        public CustomProfile()
        {
            CreateMap<DocumentType, DocumentTypeRead>();
            CreateMap<Document, DocumentRead>();
            CreateMap<Flight, FlightRead>();
            CreateMap<Role, RoleRead>();
            CreateMap<Permission, PermissionRead>();
            CreateMap<GroupPermission, GroupPermissionRead>();
        }
    }
}
