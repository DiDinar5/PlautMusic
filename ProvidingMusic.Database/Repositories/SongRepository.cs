using Microsoft.EntityFrameworkCore;
using ProvidingMusic.Database.Context;
using ProvidingMusic.Database.IRepositories;
using ProvidingMusic.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

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
        public async Task<Song?> GetSongRandomFromDbAsync()
        {
            Random random = new Random();
            var randomIndex = random.Next(0, _dbContext.Songs.Count());
            return await _dbContext.Songs.FirstOrDefaultAsync(x=>x.Id==randomIndex);
        }
        public async Task<Song> GetSongByIdFromDbAsync(string song)//изменить имя метода на имя на айди
        {
            return await _dbContext.Songs.FirstAsync(x => EF.Functions.Like(x.Name.ToLower(), $"%{song}%"));
        }
    }
}
