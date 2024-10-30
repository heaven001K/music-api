using System.ComponentModel.DataAnnotations.Schema;

namespace music.Models
{
    public class Artist
    {

        public int Id { get; set; }

        public string Name { get; set; } = "";

        public string Gender { get; set; } = "";

        public string ImageUrl { get; set; } = "";

        [NotMapped]
        public IFormFile Image { get; set; }



        public ICollection<Album> Albums { get; set; } = new List<Album>(); // Initialized the collection

        public ICollection<Music> Songs { get; set; } = new List<Music>(); // Initialized the collection
    

}
}
