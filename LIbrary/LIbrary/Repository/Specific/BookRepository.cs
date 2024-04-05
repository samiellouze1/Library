﻿using LIbrary.Data;
using LIbrary.Models;
using LIbrary.Repository.Generic;
using Microsoft.EntityFrameworkCore;
using System.Transactions;

namespace LIbrary.Repository.Specific
{
    public class BookRepository : EntityBaseRepository<Book>, IBookRepository
    {
        public BookRepository(AppDbContext context) : base(context)
        {

        }

        public async Task<Book> GetEagerBookByIdAsync(string id)
        {
            var book = await _context.Set<Book>()
                .Include(b => b.author)
                .Include(b => b.genre)
                .Include(b => b.bookCopies)
                .ThenInclude(bc=>bc.borrowItems)
                .FirstOrDefaultAsync(b=>b.Id== id);
            if (book == null)
            {
                throw new Exception();
            }
            else
            {
                return book;
            }
        }

        public async Task<ICollection<Book>> GetAllEagerBooksAsync()
        {
            var books = await _context.Set<Book>()
                .Include(b => b.author)
                .Include(b => b.bookCopies)
                .ThenInclude(bc => bc.borrowItems)
                .ToListAsync();
            return books;
        }
    }
}
