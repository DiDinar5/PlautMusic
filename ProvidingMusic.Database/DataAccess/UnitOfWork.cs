using ProvidingMusic.Database.Context;
using ProvidingMusic.Database.Repositories;
using ProvidingMusic.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvidingMusic.Database.DataAccess
{
    public class UnitOfWork: IDisposable
    {
        private readonly ApplicationDBContext _dbContext;
        private GenericRepository<Song> _songRepository;
        private readonly GenericRepository<Album> _albumRepository;

        public GenericRepository<Song> SongRepositoryUOW
        {
            get
            {
                if (this._songRepository == null)
                {
                    this._songRepository = new GenericRepository<Song>(_dbContext);
                }
                return _songRepository;
            }
        }
        public void Save()
        {
            _dbContext.SaveChanges();
        }
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
