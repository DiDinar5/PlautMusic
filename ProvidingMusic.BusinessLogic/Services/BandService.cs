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
        public BandService(IGenericRepository<Band> genericRandomRepository,
            IGenericRandomService<Band> genericRandomBLL,
            IGenericSearchByNameService<Band> genericSearchByNameService,
            IBandRepository groupMusicRepository): base(genericRandomRepository) 
        {
            _genericRandomBLL = genericRandomBLL;
            _genericSearchByNameService = genericSearchByNameService;
            _bandRepository = groupMusicRepository;
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
            return await _bandRepository.GetAllInfo(id);
        }

        //public async Task<bool> DeleteAllInfo(int id)
        //{
        //    return await _bandRepository.DeleteAllInfo(id);
        //}
    }
}
