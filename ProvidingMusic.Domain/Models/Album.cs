using System.ComponentModel.DataAnnotations;

namespace ProvidingMusic.Domain.Models
{
    public class Album: NameEntity
    {
        [Required]
        public int YearOfRelease { get; set; }

        [Required]
        public List<Song> ListSongs { get; set; } = new();
    }
}
