using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CoreOne.Core;
using CoreOne.Data;

namespace CoreOne.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantsController : ControllerBase
    {
        private readonly OdeToFoodDbContext _context;

        public RestaurantsController(OdeToFoodDbContext context)
        {
            _context = context;
        }

        // GET: api/Restaurants
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Restaunrant>>> GetRestaunrants()
        {
            return await _context.Restaunrants.ToListAsync();
        }

        // GET: api/Restaurants/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Restaunrant>> GetRestaunrant(int id)
        {
            var restaunrant = await _context.Restaunrants.FindAsync(id);

            if (restaunrant == null)
            {
                return NotFound();
            }

            return restaunrant;
        }

        // PUT: api/Restaurants/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRestaunrant(int id, Restaunrant restaunrant)
        {
            if (id != restaunrant.Id)
            {
                return BadRequest();
            }

            _context.Entry(restaunrant).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RestaunrantExists(id))
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

        // POST: api/Restaurants
        [HttpPost]
        public async Task<ActionResult<Restaunrant>> PostRestaunrant(Restaunrant restaunrant)
        {
            _context.Restaunrants.Add(restaunrant);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRestaunrant", new { id = restaunrant.Id }, restaunrant);
        }

        // DELETE: api/Restaurants/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Restaunrant>> DeleteRestaunrant(int id)
        {
            var restaunrant = await _context.Restaunrants.FindAsync(id);
            if (restaunrant == null)
            {
                return NotFound();
            }

            _context.Restaunrants.Remove(restaunrant);
            await _context.SaveChangesAsync();

            return restaunrant;
        }

        private bool RestaunrantExists(int id)
        {
            return _context.Restaunrants.Any(e => e.Id == id);
        }
    }
}
