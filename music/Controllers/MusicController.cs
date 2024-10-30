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
    public class MusicController : ControllerBase
    {
        private ApiDbContext _dbContext;

        public MusicController(ApiDbContext dbcontext)
        {
            _dbContext = dbcontext;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromForm] Music music)
        {
            var imageUrl = await FileHelper.UploadFileAsync(music.Image);
            music.ImageUrl = imageUrl;
            var audioUrl = await FileHelper.UploadAudioAsync(music.AudioFile);
            music.AudioUrl = audioUrl;
            music.uploadDate = DateTime.Now;
            await _dbContext.songs.AddAsync(music);
            await _dbContext.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpGet]
        public async Task<IActionResult> GetSongs()
        {
            var songs = await _dbContext.songs
                .Select(song => new
                {
                    Id = song.Id,
                    Name = song.Title,
                    Image = song.Duration,
                    ImageUrl = song.ImageUrl,
                    AudioUrl = song.AudioUrl,

                })
                .ToListAsync();

            return Ok(songs);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> Featured()
        {
            var songs = await _dbContext.songs
                .Where(song => song.isFeatured == true)  // Застосовано where
                .Select(song => new
                {
                    Id = song.Id,
                    Name = song.Title,
                    Duration = song.Duration,      // Зміна назви поля на Duration
                    ImageUrl = song.ImageUrl,
                    AudioUrl = song.AudioUrl
                })
                .ToListAsync();

            return Ok(songs);
        
        }


        [HttpGet("[action]")]

        public async Task<IActionResult> NewSongs()
        {
            var songs = await _dbContext.songs
                .OrderByDescending(song => song.uploadDate)  // Застосовано OrderByDescending
                .Select(song => new
                {
                    Id = song.Id,
                    Name = song.Title,
                    Duration = song.Duration,      // Зміна назви поля на Duration
                    ImageUrl = song.ImageUrl,
                    AudioUrl = song.AudioUrl
                })
                .ToListAsync();

            return Ok(songs);

        }

        [HttpGet("[action]")]
        public async Task<IActionResult> Search(string query )
        {

            var songs = await _dbContext.songs
                .Where(song => song.Title.StartsWith(query))
                .Select(song => new
                {
                    Id = song.Id,
                    Name = song.Title,
                    Duration = song.Duration,      // Зміна назви поля на Duration
                    ImageUrl = song.ImageUrl,
                    AudioUrl = song.AudioUrl
                })
                .ToListAsync();

            return Ok(songs);

        }


    }
}
