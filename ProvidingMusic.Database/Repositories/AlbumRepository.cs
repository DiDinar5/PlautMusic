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
        public AlbumRepository(ApplicationDBContext dBContext, IGenericRandomRepository<Album> genericRandomRepository) : base(dBContext)
        {
            _genericRandomRepository = genericRandomRepository;
        }
        public async Task<Album?> GetRandomEntityFromDbAsync()
        {
            return await _genericRandomRepository.GetRandomEntityFromDbAsync(); //не все альбомы попадают в рандом
        }
    }
}
