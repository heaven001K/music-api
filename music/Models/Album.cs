using System.ComponentModel.DataAnnotations.Schema;

namespace music.Models
{
    public class Album
    {

        public int id { get; set; }

        public string name { get; set; }

        public string ImageUrl { get; set; }

        public int ArtistId { get; set; }


        [NotMapped]
        public IFormFile Image { get; set; }

        public ICollection<Music> songs { get; set; }
    }
}
