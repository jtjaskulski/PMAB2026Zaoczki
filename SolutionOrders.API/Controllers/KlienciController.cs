using Microsoft.AspNetCore.Mvc;
using SolutionOrders.API.Data;
using SolutionOrders.API.Models;

namespace SolutionOrders.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class KlienciController : ControllerBase
    {
        private readonly AppDbContext _context;

        public KlienciController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Klienci.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var klient = _context.Klienci.Find(id);
            if (klient == null) return NotFound();

            return Ok(klient);
        }

        [HttpPost]
        public IActionResult Post(Klient klient)
        {
            _context.Klienci.Add(klient);
            _context.SaveChanges();

            return Ok(klient);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Klient updatedKlient)
        {
            var klient = _context.Klienci.Find(id);
            if (klient == null) return NotFound();

            klient.Imie = updatedKlient.Imie;
            klient.Nazwisko = updatedKlient.Nazwisko;
            klient.Telefon = updatedKlient.Telefon;

            _context.SaveChanges();

            return Ok(klient);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var klient = _context.Klienci.Find(id);
            if (klient == null) return NotFound();

            _context.Klienci.Remove(klient);
            _context.SaveChanges();

            return Ok();
        }
    }
}