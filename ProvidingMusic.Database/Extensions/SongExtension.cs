using ProvidingMusic.Domain.Models;

namespace ProvidingMusic.DataBase.Extensions
{
    public static class SongExtension
    {
        public static string GetStringEntity(this Song song, int id)
        {
            if (song == null)
                throw new ArgumentNullException(nameof(song));

            var time = TimeSpan.FromSeconds(song.SongDuration);
            
            return $"{song.SequenceNumber}-{song.Name}-{time.Minutes}:{time.Seconds}";
        }
    }
}
