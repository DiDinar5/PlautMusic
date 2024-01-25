using AutoMapper;
using ProvidingMusic.Database.DTO;
using ProvidingMusic.Domain.Models;

namespace ProvidingMusic.BusinessLogic.AutoMapper
{
    public class AlbumToAlbumDTOMapper : Profile
    {
        public AlbumToAlbumDTOMapper()
        {
            CreateMap<Album, AlbumDTO>()
                .ForMember(a => a.AlbumDuration,
                s => s.MapFrom(sd => sd.ListSongs.Sum(l => l.SongDuration)));
        }
    }
}
