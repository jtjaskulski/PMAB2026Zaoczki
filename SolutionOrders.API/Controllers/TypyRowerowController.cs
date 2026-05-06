using Microsoft.AspNetCore.Mvc;
using SolutionOrders.API.Data;
using SolutionOrders.API.Models;

namespace SolutionOrders.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TypyRowerowController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TypyRowerowController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get() => Ok(_context.TypyRowerow.ToList());

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var item = _context.TypyRowerow.Find(id);
            return item == null ? NotFound() : Ok(item);
        }

        [HttpPost]
        public IActionResult Post(TypRoweru typ)
        {
            _context.TypyRowerow.Add(typ);
            _context.SaveChanges();
            return Ok(typ);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, TypRoweru updated)
        {
            var item = _context.TypyRowerow.Find(id);
            if (item == null) return NotFound();

            item.Nazwa = updated.Nazwa;
            item.Opis = updated.Opis;

            _context.SaveChanges();
            return Ok(item);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var item = _context.TypyRowerow.Find(id);
            if (item == null) return NotFound();

            _context.TypyRowerow.Remove(item);
            _context.SaveChanges();
            return Ok();
        }
    }
}