using AutoMapper;
using ProvidingMusic.BusinessLogic.Services.Intefaces;
using ProvidingMusic.Database.DTO;
using ProvidingMusic.Database.IRepositories;
using ProvidingMusic.Domain.Models;

namespace ProvidingMusic.BusinessLogic.Services
{
    public class SongService : GenericService<Song>, ISongService
    {
        private readonly IGenericRandomService<Song>   _genericRandomBLL;
        private readonly IGenericSearchByNameService<Song> _searchByName;
        private readonly ISongRepository? _songRepository;
        private readonly IMapper _mapper;

        public SongService(IGenericRepository<Song> genericRepository, 
            IGenericRandomService<Song> genericRandomBLL,
            IGenericSearchByNameService<Song> searchByName,
            ISongRepository songRepository,
            IMapper mapper) : base(genericRepository)
        {
            _genericRandomBLL = genericRandomBLL;
            _searchByName = searchByName;
            _songRepository = songRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SongDTO?>> GetBestSongsFromAlbums(string? bandName)
        {
            if (bandName is null)
            {
               return new List<SongDTO?>(); 
            }
            var bestSongs = await _songRepository.GetBestSongsFromAlbums(bandName)!;    
            var songsDTO = bestSongs.Select(bs=> _mapper.Map<SongDTO>(bs)).ToList();
            //var songsDTO = bestSongs.Select(s => new SongDTO
            //{
            //    Id = s.Id,
            //    Name = s.Name,
            //    SequenceNumber = s.SequenceNumber,
            //    SongDuration = s.SongDuration
            //}).ToList();

            return songsDTO ;
        }
            
        public async Task<Song> GetByNameAsync(string name)
        {
            return await _searchByName.GetByNameAsync(name);
        }

        //public async Task<IEnumerable<SongDTO>> GetLongSongs(string nameAlbum)
        //{
        //    // Создание конфигурации сопоставления
        //    var config = new MapperConfiguration(cfg => cfg.CreateMap<List<Song>, List<SongDTO>>());
        //    // Настройка AutoMapper
        //    var mapper = new Mapper(config);
        //    // сопоставление
        //    var users = mapper.Map<List<SongDTO>>(_songRepository.GetBestSongsFromAlbums(nameAlbum));
        //    return users;
        //}

        public async Task<Song> GetRandomAsync()
        {

            return await _genericRandomBLL.GetRandomAsync();
        }

        public string GetString(int id)
        {
            return _songRepository.GetString(id);
        }

        public SongDTO MapSong(int id)
        {
            var song = _songRepository.MapSong(id);
            var songDTO = _mapper.Map<SongDTO>(song);

            return songDTO;
        }
    }
}
