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
    public class Customer_UserController : ControllerBase
    {
        private readonly Assessment2_WebAPIContext _context;

        public Customer_UserController(Assessment2_WebAPIContext context)
        {
            _context = context;
        }

        // GET: api/Customer_User
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer_User>>> GetCustomer_User()
        {
            return await _context.Customer_User.ToListAsync();
        }

        // GET: api/Customer_User/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer_User>> GetCustomer_User(string id)
        {
            var customer_User = await _context.Customer_User.FindAsync(id);

            if (customer_User == null)
            {
                return NotFound();
            }

            return customer_User;
        }

        // PUT: api/Customer_User/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer_User(string id, Customer_User customer_User)
        {
            if (id != customer_User.Cust_Username)
            {
                return BadRequest();
            }

            _context.Entry(customer_User).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Customer_UserExists(id))
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

        // POST: api/Customer_User
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Customer_User>> PostCustomer_User(Customer_User customer_User)
        {
            _context.Customer_User.Add(customer_User);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Customer_UserExists(customer_User.Cust_Username))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCustomer_User", new { id = customer_User.Cust_Username }, customer_User);
        }

        // DELETE: api/Customer_User/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer_User(string id)
        {
            var customer_User = await _context.Customer_User.FindAsync(id);
            if (customer_User == null)
            {
                return NotFound();
            }

            _context.Customer_User.Remove(customer_User);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Customer_UserExists(string id)
        {
            return _context.Customer_User.Any(e => e.Cust_Username == id);
        }
    }
}
