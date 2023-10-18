using ProvidingMusic.Database.DTO;
using ProvidingMusic.Domain.Models;

namespace ProvidingMusic.BusinessLogic.Services.Intefaces
{
    public interface IBandService: IGenericService<Band>,
        IGenericRandomService<Band>,
        IGenericSearchByNameService<Band>
    {
        Task<BandDTO?> GetAllInfo(int id);
        //Task<bool> DeleteAllInfo(int id);

    }
}