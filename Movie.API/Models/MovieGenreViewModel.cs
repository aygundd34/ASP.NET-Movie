using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using Movie.API.Models;

namespace Movie.API.Models
{
    public class MovieGenreViewModel
    {
        public List<MovieModel>? Movies { get; set; }
        public SelectList? Genres { get; set; }
        public string? MovieGenre { get; set; }
        public string? SearchString { get; set; }
    }
}