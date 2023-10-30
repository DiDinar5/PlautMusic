using AutoMapper;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using ProvidingMusic.Database.DTO;
using ProvidingMusic.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvidingMusic.BusinessLogic.Services.AutoMapper
{
    public class SongToSongDTOMapper : Profile
    {
        public SongToSongDTOMapper()
        {
            CreateMap<Song, SongDTO>();
        }
    }
}
