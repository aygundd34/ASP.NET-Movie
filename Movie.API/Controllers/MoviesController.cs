using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Movie.API.Data;
using Movie.API.Models;

namespace Movie.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly MovieContext _context;

        public MoviesController(MovieContext context)
        {
            _context = context;
        }

        // GETLIST: Tüm filmleri getir
        // URL: /api/Movies/list
        [HttpGet("list")]
        public async Task<ActionResult<IEnumerable<MovieListModel>>> GetMovies()
        {
            var movies = await _context.Movie
                .Select(m => new MovieListModel { Id = m.Id, Title = m.Title })
                .ToListAsync();

            return Ok(movies);
        }



        // GET: Belirli bir ID'ye göre film getir
        // URL: /api/Movies/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<MovieModel>> GetMovie(int id)
        {
            var movie = await _context.Movie.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }
            return movie;
        }
        

// POST: Yeni bir film ekleme
        // URL: /api/movies/add
        [HttpPost("add")]
        [ProducesResponseType(typeof(MovieModel), StatusCodes.Status201Created)] // Başarılı yanıt
        [ProducesResponseType(StatusCodes.Status400BadRequest)] // Geçersiz istek
        public async Task<ActionResult<MovieModel>> PostMovie(MovieAddModel model)
        {
            if (model == null || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var movie = new MovieModel 
            {
                Title = model.Title,
                ReleaseDate = model.ReleaseDate,
                Genre = model.Genre,
                Price = model.Price,
                Rating = model.Rating
            };

            _context.Movie.Add(movie);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetMovie), new { id = movie.Id }, movie);
        }





        // PUT: Filmi güncelle
        // URL: /api/movies/update
        [HttpPut("update")]
        public async Task<IActionResult> PutMovie(MovieModel model)
        {
            if (model == null || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var movie = await _context.Movie.FindAsync(model.Id);
            if (movie == null)
            {
                return NotFound();
            }

            // Güncelleme işlemleri
            movie.Title = model.Title;
            movie.ReleaseDate = model.ReleaseDate;
            movie.Genre = model.Genre;
            movie.Price = model.Price;
            movie.Rating = model.Rating;

            _context.Entry(movie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieExists(model.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(movie);
        }

        // DELETE: Belirli bir filmi sil
        // URL: /api/movies/delete/{id}
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            var movie = await _context.Movie.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }

            _context.Movie.Remove(movie);
            await _context.SaveChangesAsync();

            return NoContent(); // Silme işlemi sonrası yanıt
        }

        private bool MovieExists(int id)
        {
            return _context.Movie.Any(e => e.Id == id);
        }
    }
}
