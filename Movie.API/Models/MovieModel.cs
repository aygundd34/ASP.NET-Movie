using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Movie.API.Models
{
    [Table("Movie")] 
    public class MovieModel
    {
        public int Id { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required] // Başlık alanının zorunlu olması için
        public string Title { get; set; }

        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Release date is required.")]
        public DateTime ReleaseDate { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$" , ErrorMessage = "Genre must start with a capital letter.")]
        [Required(ErrorMessage = "Genre is required.")]
        [StringLength(30)]
        public string Genre { get; set; }

        [Range(1, 100, ErrorMessage = "Price must be between 1 and 100.")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }

        [RegularExpression(@"^[0-9]$|^10$", ErrorMessage = "Rating can only be a whole number from 0 to 10.")]
        [StringLength(2, ErrorMessage = "Rating should be a maximum of 2 characters.")]
        public string Rating { get; set; }
    }
}