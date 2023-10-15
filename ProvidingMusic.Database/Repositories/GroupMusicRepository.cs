using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProvidingMusic.Database.Context;
using ProvidingMusic.Database.DTO;
using ProvidingMusic.Database.IRepositories;
using ProvidingMusic.Domain.Models;

namespace ProvidingMusic.Database.Repositories
{
    public class GroupMusicRepository : GenericRepository<GroupMusic>, IGroupMusicRepository
    {
        private readonly IGenericRandomRepository<GroupMusic> _genericRandomRepository;
        private readonly IGenericSearchByNameRepository<GroupMusic> _genericSearchByNameRepository;
        public GroupMusicRepository(ApplicationDBContext dBContext,
            IGenericRandomRepository<GroupMusic> genericRandomRepository,
            IGenericSearchByNameRepository<GroupMusic> genericSearchByNameRepository) : base(dBContext) 
        {
            _genericRandomRepository = genericRandomRepository;
            _genericSearchByNameRepository = genericSearchByNameRepository;
        }

        public async Task<GroupMusicDTO?> GetAllInfoGroupMusic(int id)
        {
            var bandEntity = await _dbContext.GroupsMusic
                .Include(band => band.ListAlbums)
                .ThenInclude(albSong => albSong.ListSongs)
                .Include(member => member.ListGroupMembers)
                .FirstAsync(bend => bend.Id == id);

            var musicGroupEntity = await _dbContext.GroupsMusic
                .Include(band => band.ListAlbums)
                .ThenInclude(albSong => albSong.ListSongs)
                .Include(member => member.ListGroupMembers)
                .FirstAsync(bend => bend.Id == id);

            if (musicGroupEntity == null)
                return null;

            var musicGroupDTO = new GroupMusicDTO()
            {
                Id = musicGroupEntity.Id,
                Name = musicGroupEntity.Name,
                ListAlbums = musicGroupEntity.ListAlbums.Select(x => new AlbumDTO()
                {
                    Id = x.Id,
                    Name = x.Name,
                    YearOfRelease = x.YearOfRelease,
                    ListSongs = x.ListSongs.Select(song => new SongDTO()
                    {
                        Id = song.Id,
                        Name = song.Name,
                        SequenceNumber = song.SequenceNumber,
                        SongDuration = song.SongDuration
                    }).ToList(),
                    AlbumDuration = x.ListSongs.Sum(x => x.SongDuration)
                }).ToList(),
                ListGroupMembers = musicGroupEntity.ListGroupMembers.Select(x => new GroupMemberDTO()
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,  
                }).ToList()
            };

            return musicGroupDTO;
        }

        public async Task<GroupMusic> GetRandomAsync()
        {
            return await _genericRandomRepository.GetRandomAsync();
        }
        public async Task<GroupMusic> GetByNameAsync(string name)
        {
            return await _genericSearchByNameRepository.GetByNameAsync(name);
        }
        public async Task GEt()
        {
            List<Album> listAlbum = new List<Album>();
            var x = new
            {
                Name = "test"
            };

            List<AlbumDTO> test = listAlbum.Select(x => new AlbumDTO()
            {
                Id = x.Id,
                Name = x.Name,
                YearOfRelease = x.YearOfRelease,
                ListSongs = x.ListSongs.Select(song => new SongDTO()
                {
                    Id = song.Id,
                    Name = song.Name,
                    SequenceNumber = song.SequenceNumber,
                    SongDuration = song.SongDuration
                }).ToList(),
                AlbumDuration = x.ListSongs.Sum(x => x.SongDuration)
            }).ToList(); 
        }
    }
}
