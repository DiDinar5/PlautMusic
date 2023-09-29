using System.ComponentModel.DataAnnotations;

namespace ProvidingMusic.Domain.Models
{
    public class GroupMusic
    {
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [Range(0,10)]
        public int Rating { get; set; } 
    }
}
//FluentAPI