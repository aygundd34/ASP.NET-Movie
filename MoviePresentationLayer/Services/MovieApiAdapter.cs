using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Movie.API.Models;

namespace MoviePresentationLayer.Services
{
    public class MovieApiAdapter
    {
        private readonly HttpClient _httpClient;

        public MovieApiAdapter(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("http://localhost:5141/"); // Movie.API projesinin adresi
        }

        public async Task<IEnumerable<MovieModel>> GetMoviesAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<MovieModel>>("api/movies/list");
        }

        public async Task<MovieModel> GetMovieByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<MovieModel>($"api/movies/{id}");
        }

        public async Task AddMovieAsync(MovieAddModel movieAddModel)
        {
            var response = await _httpClient.PostAsJsonAsync("api/movies/add", movieAddModel);
            response.EnsureSuccessStatusCode();
        }


        public async Task UpdateMovieAsync(MovieModel movie)
        {
            var response = await _httpClient.PutAsJsonAsync("api/movies/update", movie);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteMovieAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/movies/delete/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}