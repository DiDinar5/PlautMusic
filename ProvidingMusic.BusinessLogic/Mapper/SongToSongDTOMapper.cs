using AutoMapper;
using ProvidingMusic.Database.DTO;
using ProvidingMusic.Domain.Models;

namespace ProvidingMusic.BusinessLogic.AutoMapper
{
    public class SongToSongDTOMapper : Profile
    {
        public SongToSongDTOMapper()
        {
            CreateMap<Song, SongDTO>();
        }
    }
}
