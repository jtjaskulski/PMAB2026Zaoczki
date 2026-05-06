using Microsoft.AspNetCore.Mvc;
using SolutionOrders.API.Data;
using SolutionOrders.API.Models;

namespace SolutionOrders.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MetodyPlatnosciController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MetodyPlatnosciController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get() => Ok(_context.MetodyPlatnosci.ToList());

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var item = _context.MetodyPlatnosci.Find(id);
            return item == null ? NotFound() : Ok(item);
        }

        [HttpPost]
        public IActionResult Post(MetodaPlatnosci metoda)
        {
            _context.MetodyPlatnosci.Add(metoda);
            _context.SaveChanges();
            return Ok(metoda);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, MetodaPlatnosci updated)
        {
            var item = _context.MetodyPlatnosci.Find(id);
            if (item == null) return NotFound();

            item.Nazwa = updated.Nazwa;
            item.Opis = updated.Opis;
            item.Aktywna = updated.Aktywna;

            _context.SaveChanges();
            return Ok(item);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var item = _context.MetodyPlatnosci.Find(id);
            if (item == null) return NotFound();

            _context.MetodyPlatnosci.Remove(item);
            _context.SaveChanges();
            return Ok();
        }
    }
}