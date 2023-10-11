using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvidingMusic.Database.DTO
{
    public class GroupMemberDTO
    {
        public int Id { get; set; } 

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Position { get; set; }
    }
}
