using LIbrary.Models;

namespace LIbrary.ViewModels.Book
{
    public class BookReadVM
    {
        public string? title { get; set; }
        public string? description { get; set; }
        public DateTime dateOfCreation { get; set; }
        public string? coverUrl { get; set; }
        public int? price { get; set; }
        public Author? author { get; set; }
        public Genre? genre { get; set; }
        public string? availability { get;set; }
        public int? numberOfCopiesAvailable { get;set; }
    }
}
