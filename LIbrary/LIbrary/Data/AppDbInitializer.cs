using LIbrary.Models;
using Microsoft.AspNetCore.Identity;
using System;

namespace LIbrary.Data
{
    public class AppDbInitializer
    {
        //private List<Reader> _reader=new List<Reader>();
        //private List<Librarian> _librarian=new List<Librarian>();
        //private List<Genre> _genres=new List<Genre>();
        //private List<Author> _authors=new List<Author>();
        //private List<AvailabilityStatus> _availabilityStatuses=new List<AvailabilityStatus>();
        //private List<Book> _books=new List<Book>();
        //private List<BookCopy> _bookCopies = new List<BookCopy>();
        //private List<BookCopyStatus> _bookCopyStatuses=new List<BookCopyStatus>();
        //private List<Borrow> _borrows=new List<Borrow>();
        //private List<BorrowItem> _borrowItems=new List<BorrowItem>();
        //private List<ShoppingCartItem> _shoppingCartItems=new List<ShoppingCartItem>();
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
                context.Database.EnsureCreated();

                #region Genre

                if (!context.Genre.Any())
                {
                    context.Genre.AddRange(new List<Genre>()
                    {
                        new Genre(){Id="1",name="Science Fiction"},
                        new Genre(){Id = "2", name="Mystery"},
                        new Genre(){Id = "3", name="Fantasy"}
                    });
                    context.SaveChanges();
                }
                #endregion

                #region Author
                if (!context.Author.Any())
                {
                    context.Author.AddRange(new List<Author>()
                    {
                        new Author(){Id="1",name="Isaac Asimov"},
                        new Author(){Id = "2", name="Agathe Christie"},
                        new Author(){Id = "3", name="J.R.R. Tolkien"}
                    });
                    context.SaveChanges();
                }
                #endregion

                #region BookCopyStatus
                if (!context.BookCopyStatus.Any())
                {
                    context.BookCopyStatus.AddRange(new List<BookCopyStatus>()
                    {
                        new BookCopyStatus(){Id = "1", name="Available"},
                        new BookCopyStatus(){Id = "2", name="Unavailable"},
                        new BookCopyStatus(){Id = "3", name="Return Requested"}
                    });
                    context.SaveChanges () ;
                }
                #endregion

                #region Book
                if (!context.Book.Any()) 
                {
                    string cover1 = "https://strangerthansf.com/scans/asimov-foundation.jpg";
                    string cover2 = "https://i.pinimg.com/originals/2d/1e/94/2d1e94ad9c9f89d4b89a33117f4c9134.jpg";
                    string cover3 = "https://th.bing.com/th/id/R.7e0e06b29187a30474e7f1fb5a9c5a00?rik=dOvbOHrJlio2EQ&pid=ImgRaw&r=0";
                    string cover4 = "https://th.bing.com/th/id/R.b153b1ff86943c88c6e83069209bc60c?rik=5vgr%2bkLgFYbk4g&pid=ImgRaw&r=0";
                    string cover5 = "https://th.bing.com/th/id/OIP.40xWQTKonwflRrgtTLcfZQHaL6?rs=1&pid=ImgDetMain";
                    string cover6 = "https://i.harperapps.com/covers/9780061763403/y648.jpg";
                    string cover7 = "https://th.bing.com/th/id/OIP.u1jvgQh_S5zIR3e4uX5oNwHaLH?rs=1&pid=ImgDetMain";
                    string cover8 = "https://th.bing.com/th/id/OIP.kIfx-8GhAWZxwSpLwjPb_AHaLH?rs=1&pid=ImgDetMain";
                    string cover9 = "https://i.harperapps.com/hcanz/covers/9780008433949/y648.jpg";
                    context.Book.AddRange(new List<Book>()
                    {
                        new Book(){ Id="1",coverUrl=cover1,title = "Foundation", description = "A series of novels set in a future where mathematician Hari Seldon develops a theory of psychohistory to predict the future of human civilization.", dateOfCreation = DateTime.Now, price = 20, author=context.Author.FirstOrDefault(a => a.Id == "1") ,genre= context.Genre.FirstOrDefault(g=>g.Id=="1")},
                        new Book(){ Id="2",coverUrl=cover2,title = "I, Robot", description = "A collection of interconnected short stories exploring the relationships between humans and robots, and the ethical implications of artificial intelligence.", dateOfCreation = DateTime.Now, price = 20, author=context.Author.FirstOrDefault(a => a.Id == "1") ,genre= context.Genre.FirstOrDefault(g=>g.Id=="2")},
                        new Book(){ Id="3",coverUrl=cover3,title = "The Caves of Steel", description = "A science fiction mystery novel featuring detective Elijah Baley and his robot partner, R. Daneel Olivaw, as they investigate a murder on a futuristic Earth.", dateOfCreation = DateTime.Now, price = 20, author=context.Author.FirstOrDefault(a => a.Id == "1") ,genre= context.Genre.FirstOrDefault(g=>g.Id=="3")},
                        new Book(){ Id="4",coverUrl=cover4,title = "Murder on the Orient Express", description = "One of Christie's most famous novels, featuring the brilliant Belgian detective Hercule Poirot solving a murder mystery aboard the luxurious Orient Express train.", dateOfCreation = DateTime.Now, price = 20, author=context.Author.FirstOrDefault(a => a.Id == "2") ,genre= context.Genre.FirstOrDefault(g=>g.Id=="1")},
                        new Book(){ Id="5",coverUrl=cover5,title = "And Then There Were None", description = "A classic mystery novel where ten strangers are invited to a remote island and are mysteriously killed off one by one, with the remaining guests trying to uncover the identity of the murderer.", dateOfCreation = DateTime.Now, price = 20, author=context.Author.FirstOrDefault(a => a.Id == "2") ,genre= context.Genre.FirstOrDefault(g=>g.Id=="2")},
                        new Book(){ Id="6",coverUrl=cover6,title = "The Murder of Roger Ackroyd", description = "A groundbreaking mystery novel known for its clever twist ending, featuring amateur detective Hercule Poirot investigating the murder of a wealthy man in a small English village.", dateOfCreation = DateTime.Now, price = 20, author=context.Author.FirstOrDefault(a => a.Id == "2") ,genre= context.Genre.FirstOrDefault(g=>g.Id=="3")},
                        new Book(){ Id="7",coverUrl=cover7,title = "The Hobbit", description = "A beloved fantasy novel following the adventures of Bilbo Baggins, a hobbit who embarks on a quest with a group of dwarves and the wizard Gandalf to reclaim their homeland from the dragon Smaug.", dateOfCreation = DateTime.Now, price = 20, author=context.Author.FirstOrDefault(a => a.Id == "3") ,genre= context.Genre.FirstOrDefault(g=>g.Id=="1")},
                        new Book(){ Id="8",coverUrl=cover8,title = "The Lord of the Rings: The Fellowship of the Ring", description = "The first volume of Tolkien's epic high fantasy series, following the journey of Frodo Baggins and his companions as they seek to destroy the One Ring and defeat the Dark Lord Sauron.", dateOfCreation = DateTime.Now, price = 20, author=context.Author.FirstOrDefault(a => a.Id == "3") ,genre= context.Genre.FirstOrDefault(g=>g.Id=="2")},
                        new Book(){ Id="9",coverUrl=cover9,title = "The Silmarillion", description = "A collection of mythopoeic works that delve into the mythology and history of Middle-earth, including the creation myth, the deeds of the Valar and Maiar, and the tales of Elves, Men, and Dwarves.", dateOfCreation = DateTime.Now, price = 20, author=context.Author.FirstOrDefault(a => a.Id == "3") ,genre= context.Genre.FirstOrDefault(g=>g.Id=="3")}
                    });
                    context.SaveChanges();
                }
                #endregion

                #region BookCopy
                if (!context.BookCopy.Any())
                {
                    List<BookCopy> bookCopies = new List<BookCopy>();
                    int k = 0;
                    for (int i=1; i < 10; i++)
                    {
                        for (int j=0;j<10;j++)
                        {
                            k++;
                            BookCopyStatus bookCopyStatus = new BookCopyStatus();
                            switch(k)
                            {
                                case 1:
                                    bookCopyStatus = context.BookCopyStatus.FirstOrDefault(bc => bc.Id == "2");
                                    break;
                                case 11:
                                    bookCopyStatus = context.BookCopyStatus.FirstOrDefault(bc => bc.Id == "3");
                                    break;
                                default:
                                    bookCopyStatus = context.BookCopyStatus.FirstOrDefault(bc => bc.Id == "1");
                                    break;
                            }
                            bookCopies.Add(new BookCopy() { Id = k.ToString(),book=context.Book.FirstOrDefault(b=>b.Id==i.ToString()), bookCopyStatus =bookCopyStatus }) ;
                        }
                    }
                    context.BookCopy.AddRange(bookCopies);
                    context.SaveChanges();
                }
                #endregion

                #region Borrow
                if (!context.Borrow.Any())
                {
                    context.Borrow.AddRange(new List<Borrow>()
                    {
                        new Borrow(){Id="1",reader=context.Reader.FirstOrDefault(r=>r.Id=="1")}, //nekes datetime
                        new Borrow(){Id="2",reader=context.Reader.FirstOrDefault(r=>r.Id=="1")}
                    }) ;
                    context.SaveChanges();
                }
                #endregion

                #region
                if (!context.BorrowItemStatus.Any())
                {
                    context.BorrowItemStatus.AddRange(new List<BorrowItemStatus>()
                    {
                        new BorrowItemStatus(){Id="1",name="Borrowed"},
                        new BorrowItemStatus(){Id="2",name="Returned"}
                    });
                    context.SaveChanges() ;
                }
                #endregion

                #region BorrowItem
                if (!context.BorrowItem.Any())
                {
                    // Fetch required objects from the context
                    var borrow = context.Borrow.FirstOrDefault(b => b.Id == "1");
                    var bookCopy1 = context.BookCopy.FirstOrDefault(bc => bc.Id == "1");
                    var bookCopy11 = context.BookCopy.FirstOrDefault(bc => bc.Id == "11");
                    var bookCopy20 = context.BookCopy.FirstOrDefault(bc => bc.Id == "20");
                    var librarian = context.Librarian.FirstOrDefault(l => l.Id == "2");

                    context.BorrowItem.AddRange(new List<BorrowItem>()
                    {
                        // Assign objects retrieved from context to navigation properties
                        new BorrowItem { Id = "1", borrow = borrow, bookCopy = bookCopy1 ,borrowItemStatus=context.BorrowItemStatus.FirstOrDefault(bis=>bis.Id=="1")},
                        new BorrowItem { Id = "2", borrow = borrow, bookCopy = bookCopy11 ,borrowItemStatus=context.BorrowItemStatus.FirstOrDefault(bis=>bis.Id=="1")},
                        new BorrowItem { Id = "3", borrow = borrow, bookCopy = bookCopy20,borrowItemStatus=context.BorrowItemStatus.FirstOrDefault(bis=>bis.Id=="2"),librarian=librarian}
                    });
                    context.SaveChanges();
                }
                #endregion

                #region ShoppingCartItem
                if (!context.ShoppingCartItem.Any())
                {
                    // Fetch required objects from the context
                    var reader = context.Reader.FirstOrDefault(r => r.Id == "1");
                    var bookCopy = context.BookCopy.FirstOrDefault(bc => bc.Id == "2");

                    context.ShoppingCartItem.AddRange(new List<ShoppingCartItem>()
                    {
                        // Assign objects retrieved from context to navigation properties
                        new ShoppingCartItem { Id = "1", reader = reader, bookCopy = bookCopy }
                    });
                    context.SaveChanges();
                }

                #endregion

            }
        }
        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationbuilder)
        {
            using (var serviceScope = applicationbuilder.ApplicationServices.CreateScope())
            {
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                #region roles
                if (!await roleManager.RoleExistsAsync(UserRoles.Reader))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Reader));
                if (!await roleManager.RoleExistsAsync(UserRoles.Librarian))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Librarian));
                #endregion
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
                #region users
                //reader
                string readerEmail = "Reader@library.com";
                var reader = await userManager.FindByEmailAsync(readerEmail);
                if (reader == null)
                {
                    Reader newReader = new Reader() { Id="1",UserName = readerEmail, Email = readerEmail };
                    await userManager.CreateAsync(newReader,"Reader123@");
                    await userManager.AddToRoleAsync(newReader, UserRoles.Reader);
                }
                //librarian
                string librarianEmail = "Librarian@library.com";
                var librarian = await userManager.FindByEmailAsync(librarianEmail);
                if (librarian == null)
                {
                    Librarian newLibrarian = new Librarian {Id="2", UserName = librarianEmail, Email = librarianEmail };
                    await userManager.CreateAsync(newLibrarian, "Librarian123@");
                    await userManager.AddToRoleAsync(newLibrarian,UserRoles.Librarian);
                }
                #endregion
            }
        }
    }
}
