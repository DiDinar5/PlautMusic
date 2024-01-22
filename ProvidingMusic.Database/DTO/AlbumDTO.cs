namespace ProvidingMusic.Database.DTO
{
    public class AlbumDTO
    {
        public int Id { get; set; } 

        public string Name { get; set; }
        
        public int YearOfRelease { get; set; }

        public int AlbumDuration { get; set; }

        public List<SongDTO> ListSongs { get; set; }
    }
}
