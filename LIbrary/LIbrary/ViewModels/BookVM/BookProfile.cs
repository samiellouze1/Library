using AutoMapper;
using LIbrary.Models;
using LIbrary.Repository.Specific;
using LIbrary.Services.BookCatalogue;


namespace LIbrary.ViewModels.BookVM;

public class BookProfile : Profile
{
    public BookProfile()
    {
        CreateMap<Book, BookReadVM>()
        .ForMember(dest => dest.numberOfCopies, opt => opt.MapFrom(src => src.bookCopies.Count));
        CreateMap<Book, BookDetailedReadVM>();
    }
}

