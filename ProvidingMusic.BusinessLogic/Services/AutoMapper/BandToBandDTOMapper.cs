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
    public class BandToBandDTOMapper : Profile
    {
        public BandToBandDTOMapper()
        {
            CreateMap<Band,BandDTO>().ForMember(b=>b.Temp,
                x => x.MapFrom(s =>$"band: {s.Name}"));
        }
    }
}
