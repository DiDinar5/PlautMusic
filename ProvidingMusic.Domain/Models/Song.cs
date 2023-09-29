using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvidingMusic.Domain.Models
{
    public class Song
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Performers { get; set; }

        [Required]
        public double SongDuration { get; set; }

        [Range(0,10)]
        public int WorldRating { get; set; }
    }
}
