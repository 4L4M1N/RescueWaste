using AutoMapper;
using RescueWaste.API.DTOs;
using RescueWaste.API.Models;

namespace RescueWaste.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<PromoCode, PromocodeForListDTO>()
            .ForMember(photo => photo.PhotoUrl, opt=> {
                opt.MapFrom(src=> src.PromocodePhoto.Url);
            });
        }
    }
}