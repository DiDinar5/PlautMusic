using Microsoft.EntityFrameworkCore;
using ProvidingMusic.Database.Context;
using ProvidingMusic.Database.IRepositories;
using ProvidingMusic.Domain.Models;

namespace ProvidingMusic.Database.Repositories
{
    public class SongRepository : GenericRepository<Song>,ISongRepository
    {
        private readonly IGenericRandomRepository<Song> _randomRepository;
        public SongRepository(ApplicationDBContext dBContext,IGenericRandomRepository<Song> randomRepository) : base(dBContext)
        {
            _randomRepository = randomRepository;
        }
        public async Task<Song> GetRandomEntityFromDbAsync()
        {
            return await _randomRepository.GetRandomEntityFromDbAsync();
        }       
    }
}
