namespace ProvidingMusic.Database.DTO
{
    public class BandDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<GroupMemberDTO> ListGroupMembers { get; set; }

        public List<AlbumDTO> ListAlbums { get; set;}

        public string? Temp {  get; set; }
    }
}
