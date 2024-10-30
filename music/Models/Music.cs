using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace music.Models
{
    public class Music
    {

        public int Id { get; set; }

        public string Title { get; set; } = "";
        public string Language { get; set; } = "";
        
        public string Duration { get; set; } = "";

        public DateTime uploadDate { get; set; }

        public bool isFeatured { get; set; }

        [NotMapped]
        public IFormFile Image { get; set; }

        public string? ImageUrl { get; set; }
        [NotMapped]
        public IFormFile AudioFile { get; set; }

        public string AudioUrl { get; set; } = "";

        public int ArtistId { get; set; }

        public int? AlbumId { get; set; }
    }
}
