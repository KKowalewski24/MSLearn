using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RazorPagesIntro.Models
{
    public class Movie
    {
        #region Properties

        public int Id { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Title { get; set; }

        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        [Range(1, 100)]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        [Required]
        [StringLength(30)]
        public string Genre { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$")]
        [StringLength(5)]
        [Required]
        public string Rating { get; set; }

        #endregion

        public Movie()
        {
        }

        public Movie(int id, string title, DateTime releaseDate, decimal price, string genre,
            string rating)
        {
            Id = id;
            Title = title;
            ReleaseDate = releaseDate;
            Price = price;
            Genre = genre;
            Rating = rating;
        }

        protected bool Equals(Movie other)
        {
            return Id == other.Id && Title == other.Title &&
                   ReleaseDate.Equals(other.ReleaseDate) && Price == other.Price &&
                   Genre == other.Genre && Rating == other.Rating;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Movie) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Title, ReleaseDate, Price, Genre, Rating);
        }

        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(Title)}: {Title}," +
                   $" {nameof(ReleaseDate)}: {ReleaseDate}, {nameof(Price)}: {Price}," +
                   $" {nameof(Genre)}: {Genre}, {nameof(Rating)}: {Rating}";
        }
    }
}