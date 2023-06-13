using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.DATA.Models
{
    public class NhanVien
    {
        [Key]
        public Guid ID { get; set; }
        public string Ten { get; set; }
        public int Tuoi { get; set; }
        public int Role { get; set; }
        public string Email { get; set; }
        public int Luong { get; set; }
        public bool TrangThai  { get; set; }
    }
}
