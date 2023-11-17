using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace ProvidingMusic.Domain.Models
{
    public class Album: NameEntity
    {
        [Required]
        public int YearOfRelease { get; set; }

        [Required]
        public List<Song> ListSongs { get; set; } = new();

        public int BandId { get; set; }

        public override bool Equals(Object? other)
        {
            if ((other == null) || !this.GetType().Equals(other.GetType()))
            {
                return false;
            }
            Album album = (Album)other;
            return (album.Name == Name &&
                 album.YearOfRelease == YearOfRelease &&
                 album.ListSongs == ListSongs);
        }

        public override int GetHashCode()
        {
            int hash = Name.GetHashCode() ^ YearOfRelease.GetHashCode() ^ ListSongs.GetHashCode();
            return hash.GetHashCode();
        }
    }
}
