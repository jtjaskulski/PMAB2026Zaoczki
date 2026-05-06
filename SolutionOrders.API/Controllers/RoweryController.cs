using Microsoft.AspNetCore.Mvc;
using SolutionOrders.API.Data;
using SolutionOrders.API.Models;

namespace SolutionOrders.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoweryController : ControllerBase
    {
        private readonly AppDbContext _context;

        public RoweryController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Rowery.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var rower = _context.Rowery.Find(id);

            if (rower == null)
                return NotFound();

            return Ok(rower);
        }

        [HttpPost]
        public IActionResult Post(Rower rower)
        {
            _context.Rowery.Add(rower);
            _context.SaveChanges();

            return Ok(rower);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Rower updatedRower)
        {
            var rower = _context.Rowery.Find(id);

            if (rower == null)
                return NotFound();

            rower.Nazwa = updatedRower.Nazwa;
            rower.Typ = updatedRower.Typ;
            rower.Cena = updatedRower.Cena;
            rower.Status = updatedRower.Status;

            _context.SaveChanges();

            return Ok(rower);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var rower = _context.Rowery.Find(id);

            if (rower == null)
                return NotFound();

            _context.Rowery.Remove(rower);
            _context.SaveChanges();

            return Ok();
        }

    }
}