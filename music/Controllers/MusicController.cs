using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using music.Data;
using music.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace music.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicController : ControllerBase
    {

        private ApiDbContext _dbContext;

        public MusicController(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }



        [HttpGet]
        public IEnumerable<Music> Get()
        {
            return _dbContext.songs;
        }

        // GET api/<MusicController>/5

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {   
            var songs = await _dbContext.songs.FindAsync(id);
            if (songs == null)
            {
                return NotFound("not found at this id");
            }
            return Ok(songs);
        }

        // POST api/<MusicController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Music value)
        {
            await _dbContext.AddAsync(value);
            await _dbContext.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT api/<MusicController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Music songObj)
        {
            var song = await _dbContext.songs.FindAsync(id);
            if (song == null)
            {
                return NotFound("not found at this id");
            }
            else
            {
                song.title = songObj.title;
                song.language = songObj.language;
                song.duration = songObj.duration;
                await _dbContext.SaveChangesAsync();
                return StatusCode(StatusCodes.Status200OK);
            }

        }

        // DELETE api/<MusicController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var song = await _dbContext.songs.FindAsync(id);
            if (song == null)
            {
                return NotFound("not found at this id");
            }
            else
            {
                _dbContext.songs.Remove(song);
                await _dbContext.SaveChangesAsync();
                return Ok("correctly deleted");
            }
        }
    }
}
