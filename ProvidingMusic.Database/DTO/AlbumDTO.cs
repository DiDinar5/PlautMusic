using ProvidingMusic.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvidingMusic.Database.DTO
{
    public class AlbumDTO
    {
        public int Id { get; set; } 

        public string Name { get; set; }

        public int AlbumDuration { get; set; }

        public List<SongDTO> SongsList { get; set; }
    }
}
