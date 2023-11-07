using Microsoft.EntityFrameworkCore;
using ProvidingMusic.Database.Context;
using ProvidingMusic.Database.IRepositories;
using ProvidingMusic.DataBase.DTO;
using ProvidingMusic.DataBase.Extensions;
using ProvidingMusic.Domain.Models;

namespace ProvidingMusic.Database.Repositories
{
    public class AlbumRepository: GenericRepository<Album>, IAlbumRepository
    {
        private readonly IGenericRandomRepository<Album> _genericRandomRepository;
        private readonly IGenericSearchByNameRepository<Album> _genericSearchByNameRepository;
        public AlbumRepository(ApplicationDBContext dBContext, 
            IGenericRandomRepository<Album> genericRandomRepository,
            IGenericSearchByNameRepository<Album> genericSearchByNameRepository) : base(dBContext)
        {
            _genericRandomRepository = genericRandomRepository;
            _genericSearchByNameRepository = genericSearchByNameRepository;
        }
        public async Task<Album?> GetRandomAsync()
        {
            return await _genericRandomRepository.GetRandomAsync(); //не все альбомы попадают в рандом
        }
        public async Task<Album> GetByNameAsync(string name)
        {
            return await _genericSearchByNameRepository.GetByNameAsync(name);
        }
        public async Task<IEnumerable<GetAlbumInfoResponseDTO>> GetAlbum(string bandName)
        {

            var albumsInfo = await _dbContext.Bands
                .Include(b => b.Albums)
                .ThenInclude(a => a.ListSongs)
                .Where(x => EF.Functions.Like(x.Name.ToLower(), $"%{bandName}%"))
                .SelectMany(b => b.Albums)
                .GroupBy(a => a.Name)
                .Select(a => new
                {
                    Name = a.Key,
                    NumberOfSongs = a.SelectMany(alb => alb.ListSongs).Count(),
                    AvgSon = a.SelectMany(alb => alb.ListSongs).Average(s=>s.SongDuration)
                }).ToListAsync();

            var albumsInfoDTO = albumsInfo.Select(a => new GetAlbumInfoResponseDTO()
            {
                Name = a.Name,
                NumberOfSongs = a.NumberOfSongs,
                AverageSongDuration = a.AvgSon
            });

            return albumsInfoDTO;
        }
        public string GetSongsFromAlbum(int id)
        {
            var albumEntity = _dbContext.Albums
                .Include(a=>a.ListSongs)
                .FirstOrDefault(a=>a.Id==id);
            return albumEntity.GetSongsFromAlbum(id);
        }
    }
}
