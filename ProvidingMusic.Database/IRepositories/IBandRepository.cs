using ProvidingMusic.Database.DTO;
using ProvidingMusic.Domain.Models;
using System.Text.RegularExpressions;

namespace ProvidingMusic.Database.IRepositories
{
    public interface IBandRepository : IGenericRepository<Band>,
        IGenericRandomRepository<Band>,
        IGenericSearchByNameRepository<Band>
    {
        Task<Band?> GetAllInfo(int id);
        //Task<bool> DeleteAllInfo(int id);

        Task<List<BandDTO?>> UpdateAllAsync(List<BandDTO?>band);

        Task<BandDTO?> TestSetValues(BandDTO bandDTO);
    }
}
