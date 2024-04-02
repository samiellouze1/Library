using AutoMapper;
using LIbrary.Models;


namespace LIbrary.ViewModels.BookVM;

public class BookProfile : Profile
{
    public BookProfile()
    {
        CreateMap<Book, BookReadVM>()
            .ForMember(dest => dest.isAvailable, opt => opt.MapFrom(src => GetAvailability(src)))
            .ForMember(dest => dest.numberOfCopiesAvailable, opt => opt.MapFrom(src => GetNumberOfCopiesAvailable(src)));
    }

    private bool GetAvailability(Book book)
    {
        if (book.bookCopies.Any(copy => copy.bookCopyStatus.name == "Available"))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private int GetNumberOfCopiesAvailable(Book book)
    {
        return book.bookCopies.Count(copy => copy.bookCopyStatus.name == "Available");
    }

}

