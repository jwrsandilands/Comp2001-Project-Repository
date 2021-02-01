using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using COMP2001_WebProj.Models;

namespace COMP2001_WebProj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PasswordsController : ControllerBase
    {
        private readonly COMP2001_JSandilandsContext _context;

        public PasswordsController(COMP2001_JSandilandsContext context)
        {
            _context = context;
        }

        // GET: api/Passwords
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Password>>> GetPasswords()
        {
            return await _context.Passwords.ToListAsync();
        }

        // GET: api/Passwords/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Password>> GetPassword(int id)
        {
            var password = await _context.Passwords.FindAsync(id);

            if (password == null)
            {
                return NotFound();
            }

            return password;
        }

        // PUT: api/Passwords/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPassword(int id, Password password)
        {
            if (id != password.Userid)
            {
                return BadRequest();
            }

            _context.Entry(password).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PasswordExists(id))
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

        // POST: api/Passwords
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Password>> PostPassword(Password password)
        {
            _context.Passwords.Add(password);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PasswordExists(password.Userid))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPassword", new { id = password.Userid }, password);
        }

        // DELETE: api/Passwords/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Password>> DeletePassword(int id)
        {
            var password = await _context.Passwords.FindAsync(id);
            if (password == null)
            {
                return NotFound();
            }

            _context.Passwords.Remove(password);
            await _context.SaveChangesAsync();

            return password;
        }

        private bool PasswordExists(int id)
        {
            return _context.Passwords.Any(e => e.Userid == id);
        }
    }
}
