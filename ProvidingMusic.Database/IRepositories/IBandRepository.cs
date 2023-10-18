using ProvidingMusic.Database.DTO;
using ProvidingMusic.Domain.Models;
using System.Text.RegularExpressions;

namespace ProvidingMusic.Database.IRepositories
{
    public interface IBandRepository : IGenericRepository<Band>,
        IGenericRandomRepository<Band>,
        IGenericSearchByNameRepository<Band>
    {
        Task<BandDTO?> GetAllInfo(int id);
        //Task<bool> DeleteAllInfo(int id);
    }
}
