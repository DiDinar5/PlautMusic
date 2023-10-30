using Microsoft.EntityFrameworkCore;
using ProvidingMusic.Database.Context;
using ProvidingMusic.Database.IRepositories;
using ProvidingMusic.Domain.Models;

namespace ProvidingMusic.Database.Repositories
{
    public class SongRepository : GenericRepository<Song>,ISongRepository
    {
        private readonly IGenericRandomRepository<Song> _randomRepository;
        private readonly IGenericSearchByNameRepository<Song> _genericSearchByNameRepository;
        public SongRepository(ApplicationDBContext dBContext,
            IGenericRandomRepository<Song> randomRepository,
            IGenericSearchByNameRepository<Song> genericSearchByNameRepository) : base(dBContext)
        {
            _randomRepository = randomRepository;
            _genericSearchByNameRepository = genericSearchByNameRepository;
        }
        public async Task<Song?> GetRandomAsync()
        {
            return await _randomRepository.GetRandomAsync();
        }

        public async Task<Song> GetByNameAsync(string name)
        {
            return await _genericSearchByNameRepository.GetByNameAsync(name);
        }

        public async Task<IEnumerable<Song>> GetLongSongs(string nameAlbum)
        {
            var songs = (await _dbContext.Albums
                .Include(s => s.ListSongs)
                .Select(s => new
                {
                    s.ListSongs,
                    s.Name
                })
                .FirstOrDefaultAsync(x => EF.Functions.Like(x.Name.ToLower(), $"%{nameAlbum}%")))?.ListSongs;

            return songs;
        }

        public async Task<IEnumerable<Song>>? GetBestSongsFromAlbums(string bandName)
        {
            var bandEntity = await _dbContext.Bands
               .Include(b => b.Albums)
               .ThenInclude(a => a.ListSongs)
               .Where(x => EF.Functions.Like(x.Name.ToLower(), $"%{bandName}%"))
               .SelectMany(b => b.Albums.SelectMany(a => a.ListSongs))
               .Where(s => s.SequenceNumber == 1)
               .ToListAsync();

            return bandEntity; 
        }

        public Song MapSong(int id)
        {
            return _dbContext.Songs.Find(id);
        }
    }
}
