using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtakDomainHotelBackend.Core.DTOs
{
    public class HotelListDTO
    {
        public int id { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public double stars { get; set; }
        
    }
}
