using laba.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace laba.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtworksController : ControllerBase
    {
        private readonly anton291_Context _context;

        public ArtworksController(anton291_Context context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Artwork>>> GetArtworks()
        {
            return await _context.Artworks.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Artwork>> GetArtwork(int id)
        {
            var artwork = await _context.Artworks.FindAsync(id);
            if (artwork == null)
            {
                return NotFound();
            }
            return artwork;
        }

        [HttpPost]
        public async Task<ActionResult<Artwork>> CreateArtwork(Artwork artwork)
        {
            _context.Artworks.Add(artwork);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetArtwork), new { id = artwork.Id }, artwork);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateArtwork(int id, Artwork artwork)
        {
            if (id != artwork.Id)
            {
                return BadRequest();
            }

            _context.Entry(artwork).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Artworks.Any(a => a.Id == id))
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArtwork(int id)
        {
            var artwork = await _context.Artworks.FindAsync(id);
            if (artwork == null)
            {
                return NotFound();
            }

            _context.Artworks.Remove(artwork);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
