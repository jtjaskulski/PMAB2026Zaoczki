using Microsoft.AspNetCore.Mvc;
using SolutionOrders.API.Data;
using SolutionOrders.API.Models;

namespace SolutionOrders.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class KategorieController : ControllerBase
    {
        private readonly AppDbContext _context;

        public KategorieController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get() => Ok(_context.Kategorie.ToList());

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var item = _context.Kategorie.Find(id);
            return item == null ? NotFound() : Ok(item);
        }

        [HttpPost]
        public IActionResult Post(Kategoria kategoria)
        {
            _context.Kategorie.Add(kategoria);
            _context.SaveChanges();
            return Ok(kategoria);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Kategoria updated)
        {
            var item = _context.Kategorie.Find(id);
            if (item == null) return NotFound();

            item.Nazwa = updated.Nazwa;
            item.Opis = updated.Opis;

            _context.SaveChanges();
            return Ok(item);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var item = _context.Kategorie.Find(id);
            if (item == null) return NotFound();

            _context.Kategorie.Remove(item);
            _context.SaveChanges();
            return Ok();
        }
    }
}