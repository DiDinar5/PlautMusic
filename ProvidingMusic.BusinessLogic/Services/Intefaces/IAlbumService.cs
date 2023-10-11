using ProvidingMusic.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvidingMusic.BusinessLogic.Services.Intefaces
{
    public interface IAlbumService:IGenericService<Album>,
        IGenericRandomService<Album>,
        IGenericSearchByNameService<Album>
    {}
}
