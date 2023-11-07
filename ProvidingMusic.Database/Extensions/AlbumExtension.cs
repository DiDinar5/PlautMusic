using ProvidingMusic.Domain.Models;

namespace ProvidingMusic.DataBase.Extensions
{
    public static class AlbumRepositoryExtension
    {
        public static string GetSongsFromAlbum(this Album album, int id)
        {
            if (album == null)
                throw new ArgumentNullException(nameof(album));

            var time = album.ListSongs.Select(s => TimeSpan.FromSeconds(s.SongDuration));

            var albEntity = string.Join("\n",
                album.ListSongs.Select(song => $"{song.SequenceNumber} - {song.Name} - " +
                $"{TimeSpan.FromSeconds(song.SongDuration).Minutes}:{TimeSpan.FromSeconds(song.SongDuration).Seconds}"));
            return albEntity;
        }
    }
}
