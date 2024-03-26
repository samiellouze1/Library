using LIbrary.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LIbrary.Data
{
    public class AppDbContext: IdentityDbContext<IdentityUser>
    {
        public DbSet<Author> Author { get; set; }
        public DbSet<AvailabilityStatus> AvailabilityStatus { get; set; }
        public DbSet<Book> Book { get; set; }
        public DbSet<BookCopy> BookCopy { get; set; }
        public DbSet<BookCopyStatus> BookCopyStatus { get; set; }
        public DbSet<Borrow> Borrow { get; set; }
        public DbSet<Genre> Genre { get; set; }
        public DbSet<Reader> Reader { get; set; }
        public DbSet<Librarian> Librarian { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {            
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            //define relationships
            builder.Entity<Book>().HasOne(b => b.author).WithMany(a => a.books).HasForeignKey(b => b.authorId);
            builder.Entity<Book>().HasOne(b=>b.genre).WithMany(g=>g.books).HasForeignKey(b=>b.genreId);
            builder.Entity<BookCopy>().HasOne(bc=>bc.book).WithMany(b=>b.bookCopies).HasForeignKey(bc=>bc.bookId);
            builder.Entity<BookCopy>().HasOne(bc=>bc.availabilityStatus).WithMany(a=>a.bookCopies).HasForeignKey(bc=>bc.availabilityStatusId);
            builder.Entity<BookCopy>().HasOne(bc=>bc.bookCopyStatus).WithMany(b=>b.bookCopies).HasForeignKey(bc=>bc.bookCopyStatusId);
            builder.Entity<Borrow>().HasOne(b => b.bookCopy).WithMany(b => b.borrows).HasForeignKey(b => b.bookCopyId);
            builder.Entity<Borrow>().HasOne(b=>b.librarian).WithMany(u=>u.borrows).HasForeignKey(b=>b.librarianId);
            builder.Entity<Borrow>().HasOne(b=>b.reader).WithMany(u=>u.borrows).HasForeignKey(b=>b.readerId);

            base.OnModelCreating(builder);
        }
    }
}
