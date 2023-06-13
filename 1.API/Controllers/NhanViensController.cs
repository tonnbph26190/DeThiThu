using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using _2.DATA.Context;
using _2.DATA.Models;

namespace _1.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NhanViensController : ControllerBase
    {
        private readonly NhanVienDBContext _context;

        public NhanViensController(NhanVienDBContext context)
        {
            _context = context;
        }

        // GET: api/NhanViens
        [HttpGet]
        public IEnumerable<NhanVien> GetNhanViens()
        {

            return _context.NhanViens.ToList();
        }

        // GET: api/NhanViens/5
        [HttpGet("{id}")]
        public NhanVien GetNhanVien(Guid id)
        {
            var ex = _context.NhanViens.SingleOrDefault(c => c.ID == id);
            if (ex!=null)
            {
                return ex;
            }
            return new NhanVien();
        }

        // PUT: api/NhanViens/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public string PutNhanVien(Guid id, [FromBody] NhanVien nhanVien)
        {
            try
            {
                var ex = _context.NhanViens.SingleOrDefault(c => c.ID == id);
                if (ex == null)
                {
                    return ("Sửa Thất bại");
                }

                ex.TrangThai = nhanVien.TrangThai;
                ex.Tuoi = nhanVien.Tuoi;
                ex.Luong= nhanVien.Luong;   
                ex.Email = nhanVien.Email;
                ex.Ten= nhanVien.Ten;
                ex.Role= nhanVien.Role;
                _context.Update(ex);
                _context.SaveChanges();
            }
            catch (Exception rx)
            {

                return ("lỗi" + rx);
            }
            return ("Sửa thành công");
        }

        // POST: api/NhanViens
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public string PostNhanVien(NhanVien nhanVien)
        {
            try
            {
                nhanVien.ID = Guid.NewGuid();
                _context.Add(nhanVien);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                return ("Lỗi" + ex.Message);
            }
            return " thêm thành công";
        }

        // DELETE: api/NhanViens/5
        [HttpDelete("{id}")]
        public string DeleteNhanVien(Guid id)
        {
            try
            {
                var ex = _context.NhanViens.SingleOrDefault(c => c.ID == id && c.TrangThai == true);
                if (ex==null)
                {
                    return ("Xóa Thất bại");
                }
                ex.TrangThai = false;
                _context.Update(ex);
                _context.SaveChanges();
            }
            catch (Exception rx)
            {

                return ("lỗi"+rx );
            }
            return ("Xóa thành công");
        }

        private bool NhanVienExists(Guid id)
        {
            return (_context.NhanViens?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
