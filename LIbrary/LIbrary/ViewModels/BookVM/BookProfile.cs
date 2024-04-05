using AutoMapper;
using LIbrary.Models;


namespace LIbrary.ViewModels.BookVM;

public class BookProfile : Profile
{
    public BookProfile()
    {
        CreateMap<Book, BookReadVM>()
        .ForMember(dest => dest.numberOfCopies, opt => opt.MapFrom(src => AvailableCopies(src)));
    }
    private int AvailableCopies(Book book)
    {
        var num = 0;
        foreach (var bookCopy in book.bookCopies)
        {
            bool testAvailable= !bookCopy.borrowItems.Select(bi=>bi.borrowItemStatusId).Any(bi=>bi=="1");
            if (testAvailable)
            {
                num++;
            }
        }
        return num;
    }
}

