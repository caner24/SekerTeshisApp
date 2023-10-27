using AutoMapper;
using SekerTeshis.Entity;
using SekerTeshis.Entity.DTO;
using SekerTeshisApp.Application.Account.Responses;

namespace SekerTeshisApp.WebApi.Mapping.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserDtoForRegister, User>().ReverseMap();

            CreateMap<TokenDto, LoginUserResponse>().ReverseMap();
        }
    }
}
