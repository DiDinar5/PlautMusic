using AutoMapper;
using ProvidingMusic.BusinessLogic.Services.Intefaces;
using ProvidingMusic.Database.DTO;
using ProvidingMusic.Database.IRepositories;
using ProvidingMusic.Domain.Models;

namespace ProvidingMusic.BusinessLogic.Services
{
    public class BandService : GenericService<Band>,IBandService
    {
        private readonly IGenericRandomService<Band> _genericRandomBLL;
        private readonly IGenericSearchByNameService<Band> _genericSearchByNameService;
        private readonly IBandRepository _bandRepository;
        private readonly IMapper _mapper;
        public BandService(IGenericRepository<Band> genericRandomRepository,
            IGenericRandomService<Band> genericRandomBLL,
            IGenericSearchByNameService<Band> genericSearchByNameService,
            IBandRepository groupMusicRepository,
            IMapper mapper): base(genericRandomRepository) 
        {
            _genericRandomBLL = genericRandomBLL;
            _genericSearchByNameService = genericSearchByNameService;
            _bandRepository = groupMusicRepository;
            _mapper = mapper;
        }
        public async Task<Band> GetRandomAsync()
        {
            return await _genericRandomBLL.GetRandomAsync();
        }
        public async Task<Band> GetByNameAsync(string name)
        {
            return await _genericSearchByNameService.GetByNameAsync(name);
        }

      
       
        public async Task<BandDTO?> GetAllInfo(int id)
        {

            var bandInfo = await _bandRepository.GetAllInfo(id);
            //var bandInfoDTO = _mapper.Map<BandDTO>(bandInfo);
            var bandEntityDTO = new BandDTO()
            {
                Id = bandInfo.Id,
                Name = bandInfo.Name,
                ListAlbums = bandInfo.Albums.Select(alb => new AlbumDTO()
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
                ListGroupMembers = bandInfo.GroupMembers.Select(member => new GroupMemberDTO()
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

        public async Task<List<BandDTO?>> UpdateAllAsync(List<BandDTO?> bands)
        {
            return await _bandRepository.UpdateAllAsync(bands);
        }

        public async Task<BandDTO?> TestSetValues(BandDTO bandDTO)
        {
                return await _bandRepository.TestSetValues(bandDTO);
        }
        public void Band_Counter(object? sender, EventArgs e)
        {
            if (sender is null) return;
            OperationCounterService service = (OperationCounterService)sender;
            //service.IncreaseBandOperationCounter();
            Console.WriteLine($"{service.ShowAllCounters}");
        }
        public async Task<Band?> CreateTest(Band band)
        {
            OperationCounterService service = new OperationCounterService();
            service.Counter += Band_Counter;
            service.IncreaseBandOperationCounter();
            return await _bandRepository.CreateAsync(band);
        }



        //public async Task<bool> DeleteAllInfo(int id)
        //{
        //    return await _bandRepository.DeleteAllInfo(id);
        //}
    }
}
