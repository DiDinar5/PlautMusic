using Microsoft.EntityFrameworkCore;
using ProvidingMusic.Database.Context;
using ProvidingMusic.Database.DTO;
using ProvidingMusic.Database.IRepositories;
using ProvidingMusic.Domain.Models;
using System.Xml.Linq;

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
        public async Task<Song> GetRandomAsync()
        {
            return await _randomRepository.GetRandomAsync();
        }

        public async Task<Song> GetByNameAsync(string name)
        {
            return await _genericSearchByNameRepository.GetByNameAsync(name);
        }

        public async Task<IEnumerable<SongDTO>> GetLongSongs(string nameAlbum)
        {
            var songs = (await _dbContext.Albums.Include(s=>s.ListSongs).Select(s => new{ s.ListSongs, s.Name})
                .FirstOrDefaultAsync(x => EF.Functions.Like(x.Name.ToLower(), $"%{nameAlbum}%")))?.ListSongs;

            if (songs is null)
                return Enumerable.Empty<SongDTO>();

            var songDTO = songs.Select(x => new SongDTO()
            {
                Id = x.Id,
                Name = x.Name,
                SequenceNumber = x.SequenceNumber,
                SongDuration = x.SongDuration,
            })
                .OrderByDescending(s=>s.SongDuration)
                .Take(5);

            return songDTO;
        }

        public async Task<IEnumerable<SongDTO>>? GetBestSongsFromAlbums(string bandName)
        {
            var bandEntity = await _dbContext.Bands
                .Include(b => b.Albums)
                .ThenInclude(a => a.ListSongs)
                .FirstOrDefaultAsync(x => EF.Functions.Like(x.Name.ToLower(), $"%{bandName}%"));

            if (bandEntity is null)
            {
                return null;
            }

            var listSong =  bandEntity.Albums
               .SelectMany(a => a.ListSongs)
               .OrderBy(a => a.SequenceNumber)
               .ThenByDescending(a => a.Name.Length)
               .Take(2).ToList();

            var bestSong = listSong.Select(s => new SongDTO()
            {
                Id = s.Id,
                Name = s.Name,
                SequenceNumber = s.SequenceNumber,
                SongDuration = s.SongDuration
            });

            return bestSong;
        }
    }
}
