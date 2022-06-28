using AtakDomainHotelBackend.Core.Entity;
using AtakDomainHotelBackend.Service.BaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtakDomainHotelBackend.Service.HotelRepository
{
    public interface IHotelWithStarsRepository:IBaseRepository<Hotel>
    {
        Task<IEnumerable<Hotel>> GetListHotelByStars(int stars);
    }
}
