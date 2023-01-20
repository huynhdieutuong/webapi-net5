using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWebApiApp.Data;
using MyWebApiApp.Models;
using System.Linq;

namespace MyWebApiApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoaisController : ControllerBase
    {
        private readonly MyDbContext _context;

        public LoaisController(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var dsLoai = _context.Loais.ToList();
            return Ok(dsLoai);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var loai = _context.Loais.FirstOrDefault(lo => lo.MaLoai == id);
                if (loai == null) return NotFound();
                return Ok(loai);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult Create(LoaiModel loaiModel)
        {
            try
            {
                var loai = new Loai
                {
                    TenLoai = loaiModel.TenLoai,
                };
                _context.Loais.Add(loai);
                _context.SaveChanges();
                return Ok(loai);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public IActionResult Edit(int id, LoaiModel loaiModel)
        {
            try
            {
                var loai = _context.Loais.FirstOrDefault(lo => lo.MaLoai == id);
                if (loai == null) return NotFound();
                loai.TenLoai = loaiModel.TenLoai;
                _context.SaveChanges();
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var loai = _context.Loais.FirstOrDefault(lo => lo.MaLoai == id);
                if (loai == null) return NotFound();
                _context.Loais.Remove(loai);
                _context.SaveChanges();
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
