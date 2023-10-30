using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvidingMusic.DataBase.DTO
{
    public class GetAlbumInfoResponseDTO
    {
        public string Name { get; set; }

        public int NumberOfSongs { get; set; }

        public double AverageSongDuration { get; set; }

    }
}
