using Microsoft.EntityFrameworkCore;
using ProvidingMusic.Database.Context;
using ProvidingMusic.Database.IRepositories;
using ProvidingMusic.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ProvidingMusic.Database.Repositories
{
    public class SongRepository : ISongRepository
    {
        private readonly ApplicationDBContext _dbContext;
        public SongRepository(ApplicationDBContext dBContext)
        {
            _dbContext = dBContext;
        }
        public async Task<IEnumerable<Song>> GetSongsFromDbAsync()=>
            await _dbContext.Songs.OrderBy(x=>x.Name).ToListAsync();

        public async Task<Song> GetSongByIdFromDbAsync(int id)=>
            await _dbContext.Songs.FindAsync(id);
    }
}
