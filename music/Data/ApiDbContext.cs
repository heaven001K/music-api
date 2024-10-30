using Microsoft.EntityFrameworkCore;
using music.Models;
using System.Security.Cryptography.X509Certificates;

namespace music.Data
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {
            


        }
        public DbSet<Music> songs { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Artist> Artists { get; set; }



    }

}





