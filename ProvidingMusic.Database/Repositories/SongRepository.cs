﻿using Microsoft.EntityFrameworkCore;
using ProvidingMusic.Database.Context;
using ProvidingMusic.Database.IRepositories;
using ProvidingMusic.Domain.Models;

namespace ProvidingMusic.Database.Repositories
{
    public class SongRepository : GenericRepository<Song>,ISongRepository
    {
        private readonly IGenericRandomRepository<Song> _randomRepository;
        private readonly IGenericSearchByNameRepository<Song> _genericSearchByNameRepository;
        public SongRepository(ApplicationDBContext dBContext,
            IGenericRandomRepository<Song> randomRepository,
            IGenericSearchByNameRepository<Song> genericSearchByNameRepository) : base(dBContext)
        {
            _randomRepository = randomRepository;
            _genericSearchByNameRepository = genericSearchByNameRepository;
        }
        public async Task<Song> GetRandomAsync()
        {
            return await _randomRepository.GetRandomAsync();
        }

        public async Task<Song> GetByNameAsync(string name)
        {
            return await _genericSearchByNameRepository.GetByNameAsync(name);
        }
    }
}
