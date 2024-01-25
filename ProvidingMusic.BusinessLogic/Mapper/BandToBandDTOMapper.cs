using AutoMapper;
using ProvidingMusic.Database.DTO;
using ProvidingMusic.Domain.Models;

namespace ProvidingMusic.BusinessLogic.AutoMapper
{
    public class BandToBandDTOMapper : Profile
    {
        public BandToBandDTOMapper()
        {
            CreateMap<Band, BandDTO>()
                .ForMember(bandDto => bandDto.ListAlbums, band => band.MapFrom(src => src.Albums))
                .ForMember(bandDto => bandDto.ListGroupMembers, band => band.MapFrom(src => src.GroupMembers));
        }
    }
}
