using Microsoft.AspNetCore.Mvc;
using SolutionOrders.API.Data;
using SolutionOrders.API.Models;

namespace SolutionOrders.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlatnosciController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PlatnosciController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get() => Ok(_context.Platnosci.ToList());

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var item = _context.Platnosci.Find(id);
            return item == null ? NotFound() : Ok(item);
        }

        [HttpPost]
        public IActionResult Post(Platnosc platnosc)
        {
            _context.Platnosci.Add(platnosc);
            _context.SaveChanges();
            return Ok(platnosc);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Platnosc updated)
        {
            var item = _context.Platnosci.Find(id);
            if (item == null) return NotFound();

            item.Klient = updated.Klient;
            item.Kwota = updated.Kwota;
            item.Metoda = updated.Metoda;
            item.Status = updated.Status;

            _context.SaveChanges();
            return Ok(item);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var item = _context.Platnosci.Find(id);
            if (item == null) return NotFound();

            _context.Platnosci.Remove(item);
            _context.SaveChanges();
            return Ok();
        }
    }
}