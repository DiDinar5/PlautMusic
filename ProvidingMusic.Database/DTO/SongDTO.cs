namespace ProvidingMusic.Database.DTO
{
    public class SongDTO
    {
        public int Id { get; set; } 

        public string? Name { get; set; }

        public int SequenceNumber { get; set; }

        public int SongDuration { get; set; }

    }
}
