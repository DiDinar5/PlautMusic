using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvidingMusic.Domain.Models
{
    public class GroupMember : BaseEntity
    {
        [Required]
        public string LastName { get; set; }

        [Required]
        public string Nickname { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public DateTime DateOfDeath { get; set;}
    }
}
