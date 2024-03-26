﻿using LIbrary.Data;
using LIbrary.Models;
using LIbrary.Repository.Generic;

namespace LIbrary.Repository
{
    public class BookRepository : EntityBaseRepository<Book>, IBookRepository
    {
        public BookRepository(AppDbContext context) : base(context)
        {

        }
    }
}
