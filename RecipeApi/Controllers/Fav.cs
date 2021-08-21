using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecipeApi.Data;
using RecipeApi.Models;

namespace RecipeApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class Fav : ControllerBase
    {
        private readonly DDbContext _context;

        public Fav(DDbContext context)
        {
            _context = context;
        }

        // GET: api/Fav
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Favorites>>> GetFavorites()
        {
            Response.Headers.Add("Access-Control-Allow-Origin", "*");
            return await _context.Favorites.ToListAsync();
        }

        // GET: api/Fav/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Favorites>> GetFavorites(int id)
        {
            Response.Headers.Add("Access-Control-Allow-Origin", "*");
            var favorites = await _context.Favorites.FindAsync(id);

            if (favorites == null)
            {
                return NotFound();
            }

            return favorites;
        }

        // PUT: api/Fav/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFavorites(int id, Favorites favorites)
        {
            if (id != favorites.ID)
            {
                return BadRequest();
            }

            _context.Entry(favorites).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FavoritesExists(id))
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

        // POST: api/Fav
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Favorites>> PostFavorites(Favorites favorites)
        {
            _context.Favorites.Add(favorites);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFavorites", new { id = favorites.ID }, favorites);
        }

        [HttpGet]
        public async Task<ActionResult<Favorites>> AddFavDB(String user,String ingridients, String title, String url)
        {
            Response.Headers.Add("Access-Control-Allow-Origin", "*");
            var fav = new Favorites();
            fav.Ingredeints = ingridients;
            fav.PhotoUrl = url;
            fav.Title = title;
            fav.User = user;

            _context.Favorites.Add(fav);
            await _context.SaveChangesAsync();


            return CreatedAtAction("GetFavorites", new { id = 0 }, fav);

        }


        // DELETE: api/Fav/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFavorites(int id)
        {
            var favorites = await _context.Favorites.FindAsync(id);
            if (favorites == null)
            {
                return NotFound();
            }

            _context.Favorites.Remove(favorites);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FavoritesExists(int id)
        {
            return _context.Favorites.Any(e => e.ID == id);
        }
    }
}
