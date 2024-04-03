using LIbrary.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LIbrary.Data
{
    public class AppDbContext: IdentityDbContext<IdentityUser>
    {
        public DbSet<Author> Author { get; set; }
        public DbSet<Book> Book { get; set; }
        public DbSet<BookCopy> BookCopy { get; set; }
        public DbSet<BorrowItem> BorrowItem { get; set; }
        public DbSet<Genre> Genre { get; set; }
        public DbSet<Reader> Reader { get; set; }
        public DbSet<Librarian> Librarian { get; set; }
        public DbSet<BookCopyStatus> BorrowItemStatus { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {            
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //relationships
            builder.Entity<Book>().HasOne(b => b.author).WithMany(a => a.books).HasForeignKey(b => b.authorId);
            builder.Entity<Book>().HasOne(b=>b.genre).WithMany(g=>g.books).HasForeignKey(b=>b.genreId);
            builder.Entity<BookCopy>().HasOne(b => b.book).WithMany(b => b.bookCopies).HasForeignKey(b => b.bookId);
            builder.Entity<BookCopy>().HasOne(bi => bi.bookCopyStatus).WithMany(b => b.bookCopies).HasForeignKey(bi => bi.bookCopyStatusId);
            builder.Entity<BorrowItem>().HasOne(b => b.bookCopy).WithMany(b => b.borrowItems).HasForeignKey(b => b.bookCopyId);
            builder.Entity<BorrowItem>().HasOne(bi => bi.librarian).WithMany(l => l.borrowItems).HasForeignKey(bi => bi.librarianId);
            builder.Entity<BorrowItem>().HasOne(bi => bi.reader).WithMany(b => b.borrowItems).HasForeignKey(bi => bi.readerId);
        }
    }
}
