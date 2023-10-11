using ProvidingMusic.Database.DTO;
using ProvidingMusic.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvidingMusic.Database.MusicGroup
{
    public class GroupMusicDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<GroupMemberDTO> GroupMembersList { get; set; }

        public List<AlbumDTO> AlbumsList { get; set;}
    }
}
