using System.ComponentModel.DataAnnotations;

namespace ProvidingMusic.Domain.Models
{
    public class Band : NameEntity
    {
        [Required]
        public List<GroupMember> GroupMembers { get; set; } = new();

        [Required]
        public List<Album> Albums { get; set; } = new();

        public override bool Equals(Object? other)
        {
            if ((other == null) || !this.GetType().Equals(other.GetType()))
            {
                return false;
            }
            Band band = (Band)other;
            return (band.Name == Name &&
                band.GroupMembers == GroupMembers &&
                band.Albums==Albums);//???
        }

        public override int GetHashCode()
        {
            int hash  = Name.GetHashCode() ^ GroupMembers.GetHashCode() ^ Albums.GetHashCode();
            return hash.GetHashCode();
        }
    }
}
//FluentAPI