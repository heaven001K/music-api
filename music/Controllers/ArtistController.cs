using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using music.Data;
using music.Helpers;
using music.Models;
using System.Net.Http.Headers;

namespace music.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistController : ControllerBase
    {

        private ApiDbContext _dbContext;

        public ArtistController(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromForm] Artist artist)
        {


            var imageUrl = await FileHelper.UploadFileAsync(artist.Image);
            artist.ImageUrl = imageUrl;
            await _dbContext.Artists.AddAsync(artist);
            await _dbContext.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpGet]
        public async Task<IActionResult> GetArtist()
        {
            var artists = await _dbContext.Artists
                .Select(artist => new
                {
                    Id = artist.Id,
                    Name = artist.Name,
                    Image = artist.ImageUrl
                })
                .ToListAsync();

            return Ok(artists);
        }

        [HttpGet("[action]")]

        public IActionResult ArtistDetails(int artistId)
        {
            var artistDetails = _dbContext.Artists.Where(a => a.Id == artistId).Include(a => a.Songs);
            return Ok(artistDetails);
        }
    }
}

