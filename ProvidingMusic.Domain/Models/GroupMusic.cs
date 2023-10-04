using System.ComponentModel.DataAnnotations;

namespace ProvidingMusic.Domain.Models
{
    public class GroupMusic : BaseEntity
    {
        [Range(0, 10)]
        public int WorldRating { get; set; }

        [Required]
        public DateTime DateOfFoundation { get; set; }

        [Required]
        public string Awards { get; set; }   //Array
    }
}
//FluentAPI