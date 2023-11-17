using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace ProvidingMusic.Domain.Models
{
    public class Song: NameEntity
    {
        [Required]
        public int SequenceNumber { get; set; }

        [Required]
        public int SongDuration { get; set; }

        public int AlbumId { get; set; }

        public override bool Equals(Object other)
        {
            if ((other == null) || !this.GetType().Equals(other.GetType()))
            {
                return false;
            }
            Song song = (Song)other;
            return (song.Name == Name &&
                song.SequenceNumber == SequenceNumber &&
                song.SongDuration == SongDuration);
        }

        public override int GetHashCode()
        {
            int hash = Name.GetHashCode() ^ SequenceNumber.GetHashCode() ^ SongDuration.GetHashCode();
            return hash.GetHashCode();
        }
    }
}
