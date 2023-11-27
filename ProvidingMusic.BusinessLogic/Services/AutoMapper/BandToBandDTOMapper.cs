using AutoMapper;
using ProvidingMusic.Database.DTO;
using ProvidingMusic.Domain.Models;

namespace ProvidingMusic.BusinessLogic.Services.AutoMapper
{
    public class BandToBandDTOMapper : Profile
    {
        public BandToBandDTOMapper()
        {
            //CreateMap<Band,BandDTO>().ForMember(b=>b.Temp,
            //    x => x.MapFrom(s =>$"band: {s.Name}"));
        }
    }
}
