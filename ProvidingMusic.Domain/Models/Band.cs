using System.ComponentModel.DataAnnotations;

namespace ProvidingMusic.Domain.Models
{
    public class Band : NameEntity
    {
        [Required]
        public List<GroupMember> GroupMembers { get; set; } = new();

        [Required]
        public List<Album> Albums { get; set; } = new();
    }
}
//FluentAPI