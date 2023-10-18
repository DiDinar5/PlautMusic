using System.ComponentModel.DataAnnotations;

namespace ProvidingMusic.Domain.Models
{
    public class GroupMember : BaseEntity
    {
        [Required]
        public string FirstName {  get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Position { get; set; }
    }
}
