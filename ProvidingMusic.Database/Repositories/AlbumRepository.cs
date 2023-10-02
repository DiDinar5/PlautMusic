using Microsoft.EntityFrameworkCore;
using ProvidingMusic.Database.Context;
using ProvidingMusic.Database.IRepositories;
using ProvidingMusic.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvidingMusic.Database.Repositories
{
    public class AlbumRepository: IAlbumRepository
    {
        private readonly ApplicationDBContext _dbContext;
        public AlbumRepository(ApplicationDBContext dBContext)
        {
                _dbContext = dBContext;
        }
        public async Task<IEnumerable<Album>> GetAlbumsFromDbAsync()=>
            await _dbContext.Albums.OrderBy(x=>x.Name).ToListAsync();
        
        public async Task<Album> GetAlbumByIdFromDbAsync(int id)=>
            await _dbContext.Albums.FindAsync(id);
        
    }
}
