using Microsoft.AspNetCore.Mvc;
using SolutionOrders.API.Data;
using SolutionOrders.API.Models;

namespace SolutionOrders.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WypozyczeniaController : ControllerBase
    {
        private readonly AppDbContext _context;

        public WypozyczeniaController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get() => Ok(_context.Wypozyczenia.ToList());

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var item = _context.Wypozyczenia.Find(id);
            return item == null ? NotFound() : Ok(item);
        }

        [HttpPost]
        public IActionResult Post(Wypozyczenie wypozyczenie)
        {
            _context.Wypozyczenia.Add(wypozyczenie);
            _context.SaveChanges();
            return Ok(wypozyczenie);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Wypozyczenie updated)
        {
            var item = _context.Wypozyczenia.Find(id);
            if (item == null) return NotFound();

            item.Klient = updated.Klient;
            item.Rower = updated.Rower;
            item.DataWypozyczenia = updated.DataWypozyczenia;
            item.DataZwrotu = updated.DataZwrotu;
            item.Status = updated.Status;

            _context.SaveChanges();
            return Ok(item);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var item = _context.Wypozyczenia.Find(id);
            if (item == null) return NotFound();

            _context.Wypozyczenia.Remove(item);
            _context.SaveChanges();
            return Ok();
        }
    }
}