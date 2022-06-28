using AtakDomainHotelBackend.Core.Entity;
using AtakDomainHotelBackend.Data.Context;
using AtakDomainHotelBackend.Service.BaseRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtakDomainHotelBackend.Service.HotelRepository
{
    public class HotelWithStarsRepository:BaseRepository<Hotel>,IHotelWithStarsRepository
    {
        public HotelWithStarsRepository(HotelContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Hotel>> GetListHotelByStars(int stars)
        {
            IEnumerable<Hotel>hotelsList =await _context.hotels.Where(e=>e.stars==stars).AsNoTracking().
                ToListAsync();
            return hotelsList;
        }
    }
}
