using AutoMapper;
using ProvidingMusic.Database.DTO;
using ProvidingMusic.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvidingMusic.BusinessLogic.Services.AutoMapper
{
    public class AlbumToAlbumDTOMapper : Profile
    {
        public AlbumToAlbumDTOMapper()
        {
            CreateMap<Album, AlbumDTO>().ForMember(a=>a.AlbumDuration,
                s=>s.MapFrom(sd=>sd.ListSongs.Sum(l=>l.SongDuration)));
        }
    }
}
