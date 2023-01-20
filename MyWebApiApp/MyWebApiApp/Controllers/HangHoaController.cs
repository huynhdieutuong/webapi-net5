using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWebApiApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyWebApiApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HangHoaController : ControllerBase
    {
        public static List<HangHoa> hangHoas = new List<HangHoa>();

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(hangHoas);
        }

        [HttpPost]
        public IActionResult Create(HangHoaVM hangHoaVM)
        {
            var hangHoa = new HangHoa
            {
                MaHangHoa = Guid.NewGuid(),
                TenHangHoa = hangHoaVM.TenHangHoa,
                DonGia = hangHoaVM.DonGia
            };
            hangHoas.Add(hangHoa);
            return Ok(new
            {
                Success = true,
                Data = hangHoa
            });
        }

        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            try
            {
                var hangHoa = hangHoas.FirstOrDefault(hh => hh.MaHangHoa == Guid.Parse(id));
                if (hangHoa == null) return NotFound();
                return Ok(hangHoa);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public IActionResult EditById(string id, HangHoaVM hangHoaVM)
        {
            if (id == null) return BadRequest();
            try
            {
                var hangHoa = hangHoas.FirstOrDefault(hh => hh.MaHangHoa == Guid.Parse(id));
                if (hangHoa == null) return NotFound();
                hangHoa.TenHangHoa = hangHoaVM.TenHangHoa;
                hangHoa.DonGia = hangHoaVM.DonGia;
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteById(string id)
        {
            if (id == null) return BadRequest();
            try
            {
                var hangHoa = hangHoas.FirstOrDefault(hh => hh.MaHangHoa == Guid.Parse(id));
                if (hangHoa == null) return NotFound();
                hangHoas.Remove(hangHoa);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
