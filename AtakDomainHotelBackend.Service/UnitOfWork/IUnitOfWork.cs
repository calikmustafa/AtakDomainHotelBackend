using AtakDomainHotelBackend.Core.Entity;
using AtakDomainHotelBackend.Service.BaseRepository;
using AtakDomainHotelBackend.Service.HotelRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtakDomainHotelBackend.Service.UnitOfWork
{
    public interface IUnitOfWork:IDisposable
    {
        IHotelWithStarsRepository HotelWithStarsRepository { get; }
        Task<bool> SaveAll();
    }
}
