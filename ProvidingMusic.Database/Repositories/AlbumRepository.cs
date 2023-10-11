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
    public class AlbumRepository: GenericRepository<Album>, IAlbumRepository
    {
        private readonly IGenericRandomRepository<Album> _genericRandomRepository;
        private readonly IGenericSearchByNameRepository<Album> _genericSearchByNameRepository;
        public AlbumRepository(ApplicationDBContext dBContext, 
            IGenericRandomRepository<Album> genericRandomRepository,
            IGenericSearchByNameRepository<Album> genericSearchByNameRepository) : base(dBContext)
        {
            _genericRandomRepository = genericRandomRepository;
            _genericSearchByNameRepository = genericSearchByNameRepository;
        }
        public async Task<Album?> GetRandomEntityFromDbAsync()
        {
            return await _genericRandomRepository.GetRandomEntityFromDbAsync(); //не все альбомы попадают в рандом
        }
        public async Task<Album> SearchByNameAsync(string name)
        {
            return await _genericSearchByNameRepository.SearchByNameAsync(name);
        }
    }
}
