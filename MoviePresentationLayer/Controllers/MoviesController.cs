using Microsoft.AspNetCore.Mvc;
using MoviePresentationLayer.Services;
using Movie.API.Models;
using System.Threading.Tasks;

namespace MoviePresentationLayer.Controllers
{
    public class MoviesController : Controller
    {
        private readonly MovieApiAdapter _movieApiAdapter;

        public MoviesController(MovieApiAdapter movieApiAdapter)
        {
            _movieApiAdapter = movieApiAdapter;
        }

        // Ana sayfa: Tüm filmleri listele
        public async Task<IActionResult> Index()
        {
            var movies = await _movieApiAdapter.GetMoviesAsync();
            return View(movies);
        }

        // Belirli bir filmin detaylarını göster
        public async Task<IActionResult> Details(int id)
        {
            var movie = await _movieApiAdapter.GetMovieByIdAsync(id);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }
        
        
        // GET: Movies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Movies/Create
        [HttpPost]
        public async Task<IActionResult> Create(MovieAddModel model)
        {
            if (ModelState.IsValid)
            {
                await _movieApiAdapter.AddMovieAsync(model); // Movie'yi ekleme işlemi
                ViewBag.Message = "Movie successfully added!"; // Başarı mesajı
                ModelState.Clear(); // Formu temizle
                return View(new MovieAddModel()); // Yeni bir form model ile geri döndür
            }
            return View(model); // Hata varsa aynı view ile geri dön
        }


        // Film düzenleme sayfası
        public async Task<IActionResult> Edit(int id)
        {
            var movie = await _movieApiAdapter.GetMovieByIdAsync(id);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }

// Film düzenleme işlemi
        [HttpPost]
        public async Task<IActionResult> Edit(MovieModel movieModel)
        {
            if (ModelState.IsValid)
            {
                await _movieApiAdapter.UpdateMovieAsync(movieModel);
                TempData["Message"] = "Movie successfully updated!"; // Başarı mesajı
                return RedirectToAction("Index"); // Ana sayfaya yönlendir
            }
            return View(movieModel); // Hatalı durumda aynı sayfayı geri döndür
        }


// Film silme işlemi
        public async Task<IActionResult> Delete(int id)
        {
            // Silinecek film bilgilerini almak için kullanabilirsiniz
            var movie = await _movieApiAdapter.GetMovieByIdAsync(id);
            return View(movie); // Silme onay sayfasını göster
        }

// Silme onaylandıktan sonra
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _movieApiAdapter.DeleteMovieAsync(id);
            TempData["Message"] = "Movie successfully deleted!"; // Başarı mesajı
            return RedirectToAction("Index"); // Ana sayfaya yönlendir
        }

    }
}