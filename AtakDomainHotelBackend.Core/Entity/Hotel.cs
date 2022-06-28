using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtakDomainHotelBackend.Core.Entity
{
    public class Hotel
    {
       
        public int id { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public double stars { get; set; }
        public string contact { get; set; }
        public string phone { get; set; }
        public string uri { get; set; }



    }
}
