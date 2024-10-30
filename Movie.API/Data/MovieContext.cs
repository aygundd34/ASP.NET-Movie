using Microsoft.EntityFrameworkCore;
using Movie.API.Models; 

namespace Movie.API.Data
{
    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> options) : base(options)
        {
        }

        public DbSet<MovieModel> Movie { get; set; }
    }
}