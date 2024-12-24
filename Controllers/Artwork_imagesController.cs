using laba.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace laba.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Artwork_imagesController : ControllerBase
    {
        private readonly anton291_Context _context;

        public Artwork_imagesController(anton291_Context context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ArtworkImage>>> GetArtworkImages()
        {
            return await _context.ArtworkImages.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ArtworkImage>> GetArtworkImage(int id)
        {
            var artworkImage = await _context.ArtworkImages.FindAsync(id);
            if (artworkImage == null)
            {
                return NotFound();
            }
            return artworkImage;
        }

        [HttpPost]
        public async Task<ActionResult<ArtworkImage>> CreateArtworkImage(ArtworkImage artworkImage)
        {
            _context.ArtworkImages.Add(artworkImage);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetArtworkImage), new { id = artworkImage.Id }, artworkImage);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateArtworkImage(int id, ArtworkImage artworkImage)
        {
            if (id != artworkImage.Id)
            {
                return BadRequest();
            }

            _context.Entry(artworkImage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.ArtworkImages.Any(ai => ai.Id == id))
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
        public async Task<IActionResult> DeleteArtworkImage(int id)
        {
            var artworkImage = await _context.ArtworkImages.FindAsync(id);
            if (artworkImage == null)
            {
                return NotFound();
            }

            _context.ArtworkImages.Remove(artworkImage);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
