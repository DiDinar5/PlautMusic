using System.ComponentModel.DataAnnotations;

namespace ProvidingMusic.Domain.Models
{
    public class Album: BaseEntity
    {
        [Required]
        public DateTime DateCreate{ get; set; }//performers

        [Range(0,10)]
        public int WorldRating { get; set; }

        [Required]
        public string Awards { get; set; } //Array
    }
}
