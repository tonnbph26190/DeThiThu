using _2.DATA.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.DATA.Context
{
    public class NhanVienDBContext:DbContext
    {
        public NhanVienDBContext() { }
        public NhanVienDBContext(DbContextOptions options):base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-OJ4UDNH\SQLEXPRESS;Initial Catalog=Test;Persist Security Info=True;User ID=Nbton03;Password=123"));
        }

        

        public DbSet<NhanVien> NhanViens { get; set; }


    }
}
