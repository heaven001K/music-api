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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Music>().HasData(
                new Music
                {
                    Id = 1,
                    title = "vasylky",
                    language = "en",
                    duration = "3.21"
                },
                new Music
                {
                    Id = 2,
                    title = "dmytroloh",
                    language = "uk",
                    duration = "4.31"
                });

             
        }


    }

}



