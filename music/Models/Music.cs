using System.ComponentModel.DataAnnotations.Schema;

namespace music.Models
{
    public class Music
    {

        public int Id { get; set; }

        public string title { get; set; } = "";

        public string language { get; set; } = "";

        public string duration { get; set; } = "";

        [NotMapped]
        public IFormFile Image { get; set; }

        public string? ImageUrl { get; set; }
    }
}
