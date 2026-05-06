using Microsoft.AspNetCore.Mvc;
using SolutionOrders.API.Data;
using SolutionOrders.API.Models;

namespace SolutionOrders.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SerwisyController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SerwisyController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get() => Ok(_context.Serwisy.ToList());

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var item = _context.Serwisy.Find(id);
            return item == null ? NotFound() : Ok(item);
        }

        [HttpPost]
        public IActionResult Post(Serwis serwis)
        {
            _context.Serwisy.Add(serwis);
            _context.SaveChanges();
            return Ok(serwis);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Serwis updated)
        {
            var item = _context.Serwisy.Find(id);
            if (item == null) return NotFound();

            item.Rower = updated.Rower;
            item.OpisUsterki = updated.OpisUsterki;
            item.Status = updated.Status;

            _context.SaveChanges();
            return Ok(item);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var item = _context.Serwisy.Find(id);
            if (item == null) return NotFound();

            _context.Serwisy.Remove(item);
            _context.SaveChanges();
            return Ok();
        }
    }
}