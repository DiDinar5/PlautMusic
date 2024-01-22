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

        public override bool Equals(Object other)
        {
            if ((other == null) || !this.GetType().Equals(other.GetType()))
            {
                return false;
            }
            GroupMember otherMember = (GroupMember)other;
            return (otherMember.FirstName==FirstName && 
                otherMember.LastName==LastName &&
                otherMember.Position == Position);
        }

        public override int GetHashCode()
        {
            int hash = FirstName.GetHashCode() ^ LastName.GetHashCode() ^ Position.GetHashCode();
            return hash.GetHashCode();
        }
    }
}
