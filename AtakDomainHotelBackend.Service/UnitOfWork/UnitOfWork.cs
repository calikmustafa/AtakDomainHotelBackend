using AtakDomainHotelBackend.Core.Entity;
using AtakDomainHotelBackend.Data.Context;
using AtakDomainHotelBackend.Service.BaseRepository;
using AtakDomainHotelBackend.Service.HotelRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtakDomainHotelBackend.Service.UnitOfWork
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly HotelContext _context = new();
        // repository getters
        #region RepositoryGetter
        IHotelWithStarsRepository hotelWithStarsRepository;
        #endregion


        #region RepositorySetter
        public IHotelWithStarsRepository HotelWithStarsRepository
        {
            get
            {
                if (hotelWithStarsRepository == null)
                {
                    this.hotelWithStarsRepository = new HotelWithStarsRepository(_context);
                }
                return this.hotelWithStarsRepository;
            }
        }
        #endregion

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }
    }
}
