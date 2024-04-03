﻿using LIbrary.Models;

namespace LIbrary.ViewModels.BookVM
{
    public class BookReadVM
    {
        public string? Id { get; set; }
        public string? title { get; set; }
        public string? description { get; set; }
        public DateTime dateOfCreation { get; set; }
        public string? coverUrl { get; set; }
        public int? price { get; set; }
        public Author author { get; set; } = new Author();
        public Genre genre { get; set; } = new Genre();
        public bool? isAlreadyBorrowed {  get; set; }
        public TimeLapse borrowedTimeLapse { get; set; } = new TimeLapse();
        public bool? isAvailableNow { get; set; }
        public List<TimeLapse> unavailabilityTimelapses { get; set; } = new List<TimeLapse>();
    }
}
