using AtakDomainHotelBackend.Core.DTOs;
using AtakDomainHotelBackend.Core.Entity;
using AutoMapper;

namespace AtakDomainHotelBackend.API.Helpers
{
    public class AutoMapperProfiles:Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Hotel, HotelListDTO>();
        }
    }
}
