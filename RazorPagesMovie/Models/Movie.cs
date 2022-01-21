using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RazorPagesMovie.Models
{
    public class Movie
    {
         public int ID { get; set; }

        [StringLength(60,MinimumLength =3)]
        [Required]
        public string Title { get; set; } = string.Empty;

        [Display(Name ="Release Date")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-z""'\s-,]*$")]
        [Required]
        public string Genre { get; set; } = string.Empty;

        [Range(1,1000)]
        [Column(TypeName="Decimal(18,2)")]
        public decimal Price { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-z0-9""'\s-]*$")]
        [StringLength(5)]
        [Required]
        public string Rating {get;set;} = string.Empty;
    }
}