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
    public class Rent_AgentController : ControllerBase
    {
        private readonly Assessment2_WebAPIContext _context;

        public Rent_AgentController(Assessment2_WebAPIContext context)
        {
            _context = context;
        }

        // GET: api/Rent_Agent
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Rent_Agent>>> GetRent_Agent()
        {
            return await _context.Rent_Agent.ToListAsync();
        }

        // GET: api/Rent_Agent/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Rent_Agent>> GetRent_Agent(int id)
        {
            var rent_Agent = await _context.Rent_Agent.FindAsync(id);

            if (rent_Agent == null)
            {
                return NotFound();
            }

            return rent_Agent;
        }

        // PUT: api/Rent_Agent/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRent_Agent(int id, Rent_Agent rent_Agent)
        {
            if (id != rent_Agent.Id)
            {
                return BadRequest();
            }

            _context.Entry(rent_Agent).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Rent_AgentExists(id))
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

        // POST: api/Rent_Agent
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Rent_Agent>> PostRent_Agent(Rent_Agent rent_Agent)
        {
            _context.Rent_Agent.Add(rent_Agent);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRent_Agent", new { id = rent_Agent.Id }, rent_Agent);
        }

        // DELETE: api/Rent_Agent/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRent_Agent(int id)
        {
            var rent_Agent = await _context.Rent_Agent.FindAsync(id);
            if (rent_Agent == null)
            {
                return NotFound();
            }

            _context.Rent_Agent.Remove(rent_Agent);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Rent_AgentExists(int id)
        {
            return _context.Rent_Agent.Any(e => e.Id == id);
        }
    }
}
