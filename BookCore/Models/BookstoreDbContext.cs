using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookCore.Models
{
    public class BookstoreDbContext  : DbContext
    {
        public BookstoreDbContext(DbContextOptions<BookstoreDbContext> options) : base (options)
        {

        }
        public DbSet<Auther>Authors { get; set; }
        public DbSet<Book> Books { get; set; }
    }
}
