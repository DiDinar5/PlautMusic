using ProvidingMusic.Database.DTO;
using ProvidingMusic.Domain.Models;

namespace ProvidingMusic.Database.IRepositories
{
    public interface IBandRepository : IGenericRepository<Band>,
        IGenericRandomRepository<Band>,
        IGenericSearchByNameRepository<Band>
    {
        Task<BandDTO?> GetAllInfo(int id);

        Task<List<BandDTO?>> UpdateAllAsync(List<BandDTO?>band);

    }
}
