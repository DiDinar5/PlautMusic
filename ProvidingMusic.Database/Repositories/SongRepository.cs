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
    public class SongRepository : ISongRepository //IGeneric //создать еще один репозиторий где будет доп метод //если больше одного раза то создаем новый метод и тд 
    {
        private readonly ApplicationDBContext _dbContext;
        public SongRepository(ApplicationDBContext dBContext)
        {
            _dbContext = dBContext;
        }
        public IEnumerable<Song> GetAllAsync()
        {
            return _dbContext.Songs.ToList();
        }

        public Song GetByIdAsync(int id)
        {
            return _dbContext.Songs.Find(id);
        }

        public async Task<Song?> GetSongRandomFromDbAsync()
        {
            Random random = new Random();
            var randomIndex = random.Next(0, _dbContext.Songs.Count());
            return await _dbContext.Songs.FirstOrDefaultAsync(x => x.Id == randomIndex);
        }
        public void CreateAsync(Song entity)
        {
            _dbContext.Songs.Add(entity);   
        }
        public void UpdateAsync(Song entity)
        {
            _dbContext.Attach(entity);
            _dbContext.Songs.Entry(entity).State = EntityState.Modified;
        }
        public void DeleteAsync(object id)
        {
            Song song = _dbContext.Songs.Find(id);
            _dbContext.Remove(song);
        }
        public void SaveAsync()
        {
            _dbContext.SaveChanges();
        }
    }
}
