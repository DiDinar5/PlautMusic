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

        public async Task<BandDTO?> GetAllInfo(int id)
        {
            var bandEntity = await _dbContext.Bands
                .Include(band => band.Albums)
                .ThenInclude(albSong => albSong.ListSongs)
                .Include(band => band.GroupMembers)
                .FirstAsync(band => band.Id == id);

            if (bandEntity == null)
                return null;

            //  var map = _mapper.Map<BandDTO?>(bandEntity);
            var bandEntityDTO = new BandDTO()
            {
                Id = bandEntity.Id,
                Name = bandEntity.Name,
                ListAlbums = bandEntity.Albums.Select(alb => new AlbumDTO()
                {
                    Id = alb.Id,
                    Name = alb.Name,
                    YearOfRelease = alb.YearOfRelease,
                    ListSongs = alb.ListSongs.Select(song => new SongDTO()
                    {
                        Id = song.Id,
                        Name = song.Name,
                        SequenceNumber = song.SequenceNumber,
                        SongDuration = song.SongDuration
                    })
                    .OrderBy(x => x.SequenceNumber)
                    .ToList(),
                    AlbumDuration = alb.ListSongs.Sum(song => song.SongDuration)
                })
                .OrderBy(albYear => albYear.YearOfRelease)
                .ToList(),
                ListGroupMembers = bandEntity.GroupMembers.Select(member => new GroupMemberDTO()
                {
                    Id = member.Id,
                    FirstName = member.FirstName,
                    LastName = member.LastName,
                    Position = member.Position
                })
                .OrderBy(ml => ml.LastName)
                .ThenBy(mf => mf.FirstName)
                .ToList()
            };

            return bandEntityDTO;
        }

        public async Task<Band?> GetRandomAsync()
        {
            return await _genericRandomRepository.GetRandomAsync();
        }
        public async Task<Band> GetByNameAsync(string name)
        {
            return await _genericSearchByNameRepository.GetByNameAsync(name);
        }

        public async Task<List<BandDTO?>> UpdateAllAsync(List<BandDTO?> bandsDTO)
        {

            var listBands = bandsDTO.Select(lb => new Band()
            {
                Id = lb.Id,
                Name = lb.Name,
                Albums = lb.ListAlbums.Select(alb => new Album()
                {
                    Id = alb.Id,
                    Name = alb.Name,
                    YearOfRelease = alb.YearOfRelease,
                    ListSongs = alb.ListSongs.Select(song => new Song()
                    {
                        Id = song.Id,
                        Name = song.Name,
                        SequenceNumber = song.SequenceNumber,
                        SongDuration = song.SongDuration
                    })
                    .OrderBy(x => x.SequenceNumber)
                    .ToList(),
                })
              .OrderBy(albYear => albYear.YearOfRelease)
              .ToList(),
                GroupMembers = lb.ListGroupMembers.Select(member => new GroupMember()
                {
                    Id = member.Id,
                    FirstName = member.FirstName,
                    LastName = member.LastName,
                    Position = member.Position
                })
              .OrderBy(ml => ml.LastName)
              .ThenBy(mf => mf.FirstName)
              .ToList()
            }).ToList();


            //_dbContext.Bands.UpdateRange(listBands);

            //_dbContext.Bands.ExecuteUpdate(s=>s.SetProperty(b=>b.Name,b=>b.Name));
            // _dbContext.Entry(listBands).Property(lb => lb.Select(b=>b.Name)).CurrentValue = bands.Select(b=>b.Name);//?

            //var currentState = _dbContext.Entry(listBands).State;
            //if (currentState == EntityState.Unchanged)
            //{               
            //        _dbContext.Entry(listBands).State = EntityState.Modified;
            //}
            //2//PropertyEntry.IsModified
            //foreach (var band in listBands)
            //{
            //    _dbSet.Attach(band);
            //}

            //_dbSet.AttachRange(listBands);

            //List<Band> bandsChange = new();
            //List<GroupMember> gmChange = new();
            //List<Album> albumsChange = new();
            //List<Song> songsChange = new();

            //foreach (var newBand in listBands)
            //{
            //    foreach (var dbBand in _dbSet)
            //    {
            //        if (dbBand.Name != newBand.Name)
            //        {
            //            bandsChange.Add(dbBand); 
            //        }
            //        if (dbBand.GroupMembers != newBand.GroupMembers)
            //        {
            //            gmChange.AddRange(dbBand.GroupMembers);
            //        }
            //    }
            //}
            //List<Band> changeNames = new();


            //var inet = listBands.Select(b => b.Name).Intersect(_dbSet.Select(b => b.Name));
            //foreach(var band in listBands)
            //{
            //    foreach (var db in _dbSet)
            //    {
            //        if (db.Name == band.Name)
            //        {
            //            changeNames.Add(db);
            //        }
            //    }
            //}



            //foreach (var band in changeNames)
            //{
            //    _dbContext.Entry(band).State = EntityState.Modified;  
            //}
            //var one = listBands.Where(b => b.Id == 23).First();
            //var currentState = _dbContext.Entry(one).State;


            //if (currentState == EntityState.Unchanged)
            //{
            //    _dbContext.Bands.Entry(one).State = EntityState.Modified;
            //}

            //foreach (var label in listBands)
            //    foreach (var p in _dbContext.Entry(label).Properties)
            //        p.IsModified = false;

            //List<BandDTO> bandDTO = new();
            //var d= listBands.Where(b=>b.Id==23).First();
            //var a = bands.Where(b => b.Id == 23).First();
            //_dbContext.AddRange(listBands);

            //var listDTO = new List<BandDTO>();
            //var list = new List<Band>();
            //var entitytype = _dbContext.Model.GetEntityTypes().Select(b => b.ClrType).ToList();


            var dbBands = _dbContext.Bands.
                Include(b => b.GroupMembers)
                .Include(b => b.Albums)
                .ThenInclude(a => a.ListSongs)
                .ToList();
            
            foreach (var dbBand in dbBands)
            {
               _dbContext.Entry(dbBand).CurrentValues.SetValues(bandsDTO.First(b=>b.Id==dbBand.Id)!);
            }
            await SaveAsync();


            // _dbContext.Entry(listBands).CurrentValues.SetValues(bands);


            _dbContext.ChangeTracker.DetectChanges();
            Console.WriteLine(_dbContext.ChangeTracker.DebugView.LongView);



            //var listBandsDTO = listBands.Select(lb => new BandDTO()
            //{
            //    Id = lb.Id,
            //    Name = lb.Name,
            //    ListAlbums = lb.Albums.Select(alb => new AlbumDTO()
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
            //  .OrderBy(albYear => albYear.YearOfRelease)
            //  .ToList(),
            //    ListGroupMembers = lb.GroupMembers.Select(member => new GroupMemberDTO()
            //    {
            //        Id = member.Id,
            //        FirstName = member.FirstName,
            //        LastName = member.LastName,
            //        Position = member.Position
            //    })
            //  .OrderBy(ml => ml.LastName)
            //  .ThenBy(mf => mf.FirstName)
            //  .ToList()
            //}).ToList();
            return bandsDTO;
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
