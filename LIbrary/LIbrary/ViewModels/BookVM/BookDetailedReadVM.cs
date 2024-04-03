using LIbrary.Models;

namespace LIbrary.ViewModels.BookVM
{
    public class BookDetailedReadVM
    {
        public string? Id { get; set; }
        public string? title { get; set; }
        public string? description { get; set; }
        public DateTime dateOfCreation { get; set; }
        public string? coverUrl { get; set; }
        public int? price { get; set; }
        public Author author { get; set; } = new Author();
        public Genre genre { get; set; } = new Genre();
        public bool? isAvailableNow { get; set; }
        public bool? isAlreadyBorrowed { get; set; }
        public int? numberOfCopies { get; set; }
        public int? numberOfBorrows { get; set; }
        public List<ReviewRating> ReviewRatings { get; set; }
    }
}
