using ProvidingMusic.BusinessLogic.Services.Intefaces;
using ProvidingMusic.Domain.Models;

namespace ProvidingMusic.DataBase.Comparers
{
    public static class SongEntityComparer 
    {
        private static readonly Song _song;
        private static readonly ISongService _songService;

        public static void SongNameCompare()
        {
            if (_song.Name.Equals(_song))
            {

            }
        }
    }
}
