using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using music.Data;
using music.Helpers;
using music.Models;

namespace music.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumController : ControllerBase
    {
        private ApiDbContext _dbContext;

        public AlbumController(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromForm] Album album)
        {
            var imageUrl = await FileHelper.UploadFileAsync(album.Image);
            album.ImageUrl = imageUrl;
            await _dbContext.Albums.AddAsync(album); 
            await _dbContext.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpGet]
        public async Task<IActionResult> GetAlbums()
        {
            var albs = await _dbContext.Albums
                .Select(album => new
                {
                    Id = album.Id,
                    Name = album.Name,
                    Image = album.ImageUrl
                })
                .ToListAsync();
            return Ok(albs);
            }



        [HttpGet("[action]")]

        public IActionResult AlbumsDetails(int albumId)
        {
            var albumsDetails = _dbContext.Albums.Where(a => a.Id == albumId).Include(a => a.Songs);
            return Ok(albumsDetails);
        }

    }
}
