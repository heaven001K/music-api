using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using music.Data;
using music.Helpers;
using music.Models;

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

    }
}
