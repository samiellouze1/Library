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
                        new AvailabilityStatus(){name="Not Available"}
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
                        new Book()
                    });
                    context.SaveChanges();
                }
                #endregion

                #region BookCopy
                if (!context.BookCopy.Any())
                {
                    context.BookCopy.AddRange(new List<BookCopy>()
                    {
                        new BookCopy()
                    });
                }
                #endregion

                #region BorrowItem
                if (!context.BorrowItem.Any())
                {
                    context.BorrowItem.AddRange(new List<BorrowItem>()
                    {
                        new BorrowItem()
                    });
                }
                #endregion

                #region Borrow
                if (!context.Borrow.Any())
                {
                    context.Borrow.AddRange(new List<Borrow>()
                    {
                        new Borrow()
                    });
                }
                #endregion

                #region ShoppingCartItem
                if (!context.ShoppingCartItem.Any())
                {
                    context.ShoppingCartItem.AddRange(new List<ShoppingCartItem>()
                    {
                        new ShoppingCartItem()
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
            }
        }
    }
}
