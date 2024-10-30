using System.ComponentModel.DataAnnotations.Schema;

namespace music.Models
{
    public class Album
    {

        public int Id { get; set; }

        public string Name { get; set; } = "";

        public string ImageUrl { get; set; } = "";

        public int ArtistId { get; set; }


        [NotMapped]
        public IFormFile Image { get; set; }

        public ICollection<Music> Songs { get; set; } = new List<Music>(); // Initialized the collection
    }
}
