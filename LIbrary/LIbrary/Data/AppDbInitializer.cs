using LIbrary.Models;
using Microsoft.AspNetCore.Identity;

namespace LIbrary.Data
{
    public class AppDbInitializer
    {
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
                        new Genre(){name="Science Fiction"},
                        new Genre(){name="Mystery"},
                        new Genre(){name="Fantasy"}
                    });
                    context.SaveChanges();
                }
                #endregion

                #region Author
                if (!context.Author.Any())
                {
                    context.Author.AddRange(new List<Author>()
                    {
                        new Author(){name="Isaac Asimov"},
                        new Author(){name="Agathe Christie"},
                        new Author(){name="J.R.R. Tolkien"}
                    });
                    context.SaveChanges();
                }
                #endregion

                #region AvailabilityStatus
                if (!context.AvailabilityStatus.Any())
                {
                    context.AvailabilityStatus.AddRange(new List<AvailabilityStatus>()
                    {
                        new AvailabilityStatus(){name="Available"},
                        new AvailabilityStatus(){name="UnAvailable"}
                    });
                    context.SaveChanges ();
                }
                #endregion

                #region BookCopyStatus
                if (!context.BookCopyStatus.Any())
                {
                    context.BookCopyStatus.AddRange(new List<BookCopyStatus>()
                    {
                        new BookCopyStatus(){name="Available"},
                        new BookCopyStatus(){name="Unavailable"}
                    });
                    context.SaveChanges () ;
                }
                #endregion

                #region Book
                if (!context.Book.Any()) 
                {
                    context.Book.AddRange(new List<Book>()
                    {
                        new Book(){ title = "Foundation", description = "A series of novels set in a future where mathematician Hari Seldon develops a theory of psychohistory to predict the future of human civilization.", dateOfCreation = DateTime.Now, price = 20, authorId = "1" },
                        new Book(){ title = "I, Robot", description = "A collection of interconnected short stories exploring the relationships between humans and robots, and the ethical implications of artificial intelligence.", dateOfCreation = DateTime.Now, price = 20, authorId = "1" },
                        new Book(){ title = "The Caves of Steel", description = "A science fiction mystery novel featuring detective Elijah Baley and his robot partner, R. Daneel Olivaw, as they investigate a murder on a futuristic Earth.", dateOfCreation = DateTime.Now, price = 20, authorId = "1" },
                        new Book(){ title = "Murder on the Orient Express", description = "One of Christie's most famous novels, featuring the brilliant Belgian detective Hercule Poirot solving a murder mystery aboard the luxurious Orient Express train.", dateOfCreation = DateTime.Now, price = 20, authorId = "2" },
                        new Book(){ title = "And Then There Were None", description = "A classic mystery novel where ten strangers are invited to a remote island and are mysteriously killed off one by one, with the remaining guests trying to uncover the identity of the murderer.", dateOfCreation = DateTime.Now, price = 20, authorId = "2" },
                        new Book(){ title = "The Murder of Roger Ackroyd", description = "A groundbreaking mystery novel known for its clever twist ending, featuring amateur detective Hercule Poirot investigating the murder of a wealthy man in a small English village.", dateOfCreation = DateTime.Now, price = 20, authorId = "2" },
                        new Book(){ title = "The Hobbit", description = "A beloved fantasy novel following the adventures of Bilbo Baggins, a hobbit who embarks on a quest with a group of dwarves and the wizard Gandalf to reclaim their homeland from the dragon Smaug.", dateOfCreation = DateTime.Now, price = 20, authorId = "3" },
                        new Book(){ title = "The Lord of the Rings: The Fellowship of the Ring", description = "The first volume of Tolkien's epic high fantasy series, following the journey of Frodo Baggins and his companions as they seek to destroy the One Ring and defeat the Dark Lord Sauron.", dateOfCreation = DateTime.Now, price = 20, authorId = "3" },
                        new Book(){ title = "The Lord of the Rings: The Two Towers", description = "The second volume of Tolkien's epic high fantasy series, continuing the journey of Frodo Baggins and his companions as they face new challenges and adversaries on their quest.", dateOfCreation = DateTime.Now, price = 20, authorId = "3" },
                        new Book(){ title = "The Lord of the Rings: The Return of the King", description = "The third volume of Tolkien's epic high fantasy series, culminating in the final showdown between the forces of good and evil as the fate of Middle-earth hangs in the balance.", dateOfCreation = DateTime.Now, price = 20, authorId = "3" },
                        new Book(){ title = "The Silmarillion", description = "A collection of mythopoeic works that delve into the mythology and history of Middle-earth, including the creation myth, the deeds of the Valar and Maiar, and the tales of Elves, Men, and Dwarves.", dateOfCreation = DateTime.Now, price = 20, authorId = "3" }
                    });
                    context.SaveChanges();
                }
                #endregion

                #region BookCopy
                if (!context.BookCopy.Any())
                {
                    List<BookCopy> bookCopies = new List<BookCopy>();
                    for (int i=1; i < 10; i++)
                    {
                        for (int j=0;j<10;j++)
                        {
                            bookCopies.Add(new BookCopy() { bookId = i.ToString(), availabilityStatusId = "1", bookCopyStatusId = "1" });
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
                        new Borrow(){readerId="1"}, //nekes datetime
                        new Borrow(){readerId="1"},
                        new Borrow(){readerId="2"},
                    }) ;
                }
                #endregion

                #region BorrowItem
                if (!context.BorrowItem.Any())
                {
                    context.BorrowItem.AddRange(new List<BorrowItem>()
                    {
                        new BorrowItem(){borrowId="1",bookCopyId="1",librarianId="1"},
                        new BorrowItem(){borrowId="1",bookCopyId="2",librarianId="1"}
                        //need to change status
                    });
                }
                #endregion

                #region ShoppingCartItem
                if (!context.ShoppingCartItem.Any())
                {
                    context.ShoppingCartItem.AddRange(new List<ShoppingCartItem>()
                    {
                        new ShoppingCartItem(){readerId="1", bookCopyId="2"}
                    });
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
                #region users
                #endregion
            }
        }
    }
}
