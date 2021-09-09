using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Assessment2_WebAPI.Data;
using Assessment2_WebAPI.Models;

namespace Assessment2_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Rent_HousesController : ControllerBase
    {
        private readonly Assessment2_WebAPIContext _context;

        public Rent_HousesController(Assessment2_WebAPIContext context)
        {
            _context = context;
        }

        // GET: api/Rent_Houses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Rent_Houses>>> GetRent_Houses()
        {
            return await _context.Rent_Houses.ToListAsync();
        }

        // GET: api/Rent_Houses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Rent_Houses>> GetRent_Houses(int id)
        {
            var rent_Houses = await _context.Rent_Houses.FindAsync(id);

            if (rent_Houses == null)
            {
                return NotFound();
            }

            return rent_Houses;
        }

        // PUT: api/Rent_Houses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRent_Houses(int id, Rent_Houses rent_Houses)
        {
            if (id != rent_Houses.Id)
            {
                return BadRequest();
            }

            _context.Entry(rent_Houses).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Rent_HousesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Rent_Houses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Rent_Houses>> PostRent_Houses(Rent_Houses rent_Houses)
        {
            _context.Rent_Houses.Add(rent_Houses);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRent_Houses", new { id = rent_Houses.Id }, rent_Houses);
        }

        // DELETE: api/Rent_Houses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRent_Houses(int id)
        {
            var rent_Houses = await _context.Rent_Houses.FindAsync(id);
            if (rent_Houses == null)
            {
                return NotFound();
            }

            _context.Rent_Houses.Remove(rent_Houses);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Rent_HousesExists(int id)
        {
            return _context.Rent_Houses.Any(e => e.Id == id);
        }
    }
}
