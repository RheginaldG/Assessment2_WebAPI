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
    public class Rent_DetailsController : ControllerBase
    {
        private readonly Assessment2_WebAPIContext _context;

        public Rent_DetailsController(Assessment2_WebAPIContext context)
        {
            _context = context;
        }

        // GET: api/Rent_Details
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Rent_Details>>> GetRent_Details()
        {
            return await _context.Rent_Details.ToListAsync();
        }

        // GET: api/Rent_Details/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Rent_Details>> GetRent_Details(int id)
        {
            var rent_Details = await _context.Rent_Details.FindAsync(id);

            if (rent_Details == null)
            {
                return NotFound();
            }

            return rent_Details;
        }

        // PUT: api/Rent_Details/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRent_Details(int id, Rent_Details rent_Details)
        {
            if (id != rent_Details.Id)
            {
                return BadRequest();
            }

            _context.Entry(rent_Details).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Rent_DetailsExists(id))
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

        // POST: api/Rent_Details
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Rent_Details>> PostRent_Details(Rent_Details rent_Details)
        {
            _context.Rent_Details.Add(rent_Details);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRent_Details", new { id = rent_Details.Id }, rent_Details);
        }

        // DELETE: api/Rent_Details/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRent_Details(int id)
        {
            var rent_Details = await _context.Rent_Details.FindAsync(id);
            if (rent_Details == null)
            {
                return NotFound();
            }

            _context.Rent_Details.Remove(rent_Details);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Rent_DetailsExists(int id)
        {
            return _context.Rent_Details.Any(e => e.Id == id);
        }
    }
}
