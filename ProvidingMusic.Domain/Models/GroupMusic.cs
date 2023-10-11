using System.ComponentModel.DataAnnotations;

namespace ProvidingMusic.Domain.Models
{
    public class GroupMusic : NameEntity
    {
        [Required]
        public List<GroupMember> ListGroupMembers { get; set; } = new();

        [Required]
        public List<Album> ListAlbums { get; set; } = new();
    }
}
//FluentAPI