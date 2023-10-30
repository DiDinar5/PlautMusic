using Microsoft.EntityFrameworkCore;
using ProvidingMusic.Database.Context;
using ProvidingMusic.Database.DTO;
using ProvidingMusic.Database.IRepositories;
using ProvidingMusic.Domain.Models;

namespace ProvidingMusic.Database.Repositories
{
    public class BandRepository : GenericRepository<Band>, IBandRepository
    {
        private readonly IGenericRandomRepository<Band> _genericRandomRepository;
        private readonly IGenericSearchByNameRepository<Band> _genericSearchByNameRepository;
        public BandRepository(ApplicationDBContext dBContext,
            IGenericRandomRepository<Band> genericRandomRepository,
            IGenericSearchByNameRepository<Band> genericSearchByNameRepository) : base(dBContext)
        {
            _genericRandomRepository = genericRandomRepository;
            _genericSearchByNameRepository = genericSearchByNameRepository;
        }

        public async Task<Band?> GetAllInfo(int id)
        {
            var bandEntity = await _dbContext.Bands
                .Include(band => band.Albums)
                .ThenInclude(albSong => albSong.ListSongs)
                .Include(band => band.GroupMembers)
                .FirstAsync(band => band.Id == id);

            //if (bandEntity == null)
            //    return null;

          //  var map = _mapper.Map<BandDTO?>(bandEntity);
            //var bandEntityDTO = new BandDTO()
            //{
            //    Id = bandEntity.Id,
            //    Name = bandEntity.Name,
            //    ListAlbums = bandEntity.Albums.Select(alb => new AlbumDTO()
            //    {
            //        Id = alb.Id,
            //        Name = alb.Name,
            //        YearOfRelease = alb.YearOfRelease,
            //        ListSongs = alb.ListSongs.Select(song => new SongDTO()
            //        {
            //            Id = song.Id,
            //            Name = song.Name,
            //            SequenceNumber = song.SequenceNumber,
            //            SongDuration = song.SongDuration
            //        })
            //        .OrderBy(x => x.SequenceNumber)
            //        .ToList(),
            //        AlbumDuration = alb.ListSongs.Sum(song => song.SongDuration)
            //    })
            //    .OrderBy(albYear => albYear.YearOfRelease)
            //    .ToList(),
            //    ListGroupMembers = bandEntity.GroupMembers.Select(member => new GroupMemberDTO()
            //    {
            //        Id = member.Id,
            //        FirstName = member.FirstName,
            //        LastName = member.LastName,
            //        Position = member.Position
            //    })
            //    .OrderBy(ml => ml.LastName)
            //    .ThenBy(mf => mf.FirstName)
            //    .ToList()
            //};

            return bandEntity;
        }

        public async Task<Band?> GetRandomAsync()
        {
            return await _genericRandomRepository.GetRandomAsync();
        }
        public async Task<Band> GetByNameAsync(string name)
        {
            return await _genericSearchByNameRepository.GetByNameAsync(name);
        }

        //public async Task<bool> DeleteAllInfo(int id)
        //{
        //    var bandEntity = await _dbContext.Bands
        //       .Include(band => band.ListAlbums)
        //       .ThenInclude(albSong => albSong.ListSongs)
        //       .Include(band => band.ListGroupMembers)
        //       .FirstAsync(band => band.Id == id);

        //    var remove = new List<Band>();
        //    var c = remove.RemoveAll(band => band.Id == id);
        //    await SaveAsync();
        //    return true;
        //}
    }
}
