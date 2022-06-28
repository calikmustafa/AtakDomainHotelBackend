using AtakDomainHotelBackend.Core.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtakDomainHotelBackend.Data.Context
{
    public  partial class HotelContext:DbContext
    {
        public HotelContext()
        {
        }
        public HotelContext(DbContextOptions<HotelContext> options)
       : base(options)
        {
        }

        public virtual DbSet<Hotel> hotels { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=MSI\\SQLEXPRESS;Initial Catalog=Hotel;Trusted_Connection=true");
            }
        }
    }
    

   
}
