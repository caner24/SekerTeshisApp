using AutoMapper;
using SekerTeshis.Entity;
using SekerTeshis.Entity.DTO;

namespace SekerTeshisApp.WebApi.Mapping.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserDtoForRegister, User>().ReverseMap();
        }
    }
}
