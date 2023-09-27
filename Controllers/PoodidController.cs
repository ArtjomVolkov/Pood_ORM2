using Microsoft.AspNetCore.Mvc;
using Pood.Data;
using Pood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Pood.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PoodidiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PoodidiController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<Poodi> Get()
        {
            var pood = _context.Pood.ToList();
            return pood;
        }

        [HttpPost("lisa")]
        public List<Poodi> LisaPood([FromBody] Poodi pood)
        {
            _context.Pood.Add(pood);
            _context.SaveChanges(); // Сохраните изменения в базе данных
            return _context.Pood.ToList(); // Верните обновленный список магазинов
        }

        [HttpGet("lahtipood/{tund}/{minut}")]
        public IActionResult LahtiPood(int tund, int minut)
        {
            TimeSpan kellaaeg = new TimeSpan(tund, minut, 0);

            var lahtiPoed = _context.Pood.AsEnumerable().Where(p => p.OnLahti(kellaaeg)).Select(p => p.Nimi).ToList(); // Принудительно выполнить остальную часть запроса на стороне клиента

            if (lahtiPoed.Count > 0)
            {
                return Ok(lahtiPoed);
            }
            else
            {
                return NotFound("Ühtegi poodi pole sel ajal lahti.");
            }
        }

        [HttpDelete("kustuta/{id}")]
        public IActionResult Delete(int id)
        {
            var poodToDelete = _context.Pood.FirstOrDefault(p => p.Id == id); // Поиск магазина по Id
            if (poodToDelete != null)
            {
                _context.Pood.Remove(poodToDelete);
                _context.SaveChanges(); // Сохраните изменения в базе данных
                return Ok(_context.Pood.ToList()); // Верните обновленный список магазинов
            }
            else
            {
                return NotFound($"Poodi Id {id} ei leitud.");
            }
        }

        [HttpPost("kylasta/{poodiNimi}")]
        public IActionResult kylasta([FromRoute] string poodiNimi)
        {
            var pood = _context.Pood.FirstOrDefault(p => p.Nimi == poodiNimi);
            if (pood != null)
            {
                pood.KuulastusteArv += 1;
                _context.SaveChanges(); // Сохраните изменения в базе данных
                return Ok(pood.KuulastusteArv);
            }
            else
            {
                return NotFound($"Poodi nimega {poodiNimi} ei leitud.");
            }
        }

    }
}
