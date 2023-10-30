using System.ComponentModel.DataAnnotations;

namespace ProvidingMusic.Domain.Models
{
    public class Song: NameEntity
    {
        [Required]
        public int SequenceNumber { get; set; }

        [Required]
        public int SongDuration { get; set; }

        public int AlbumId { get; set; }
    }
}
