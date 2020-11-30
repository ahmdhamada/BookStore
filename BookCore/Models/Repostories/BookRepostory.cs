using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookCore.Models.Repostories
{
    public class BookRepostory : IBookstoreRepostory<Book>
    {
        List<Book> books;

        public BookRepostory()
        {
            books = new List<Book>()
            {
                new Book
                {
                    Id=1,Title="programming",Description="software engineering", Auther=new Auther()
                },
                 new Book
                {
                    Id=2,Title="java",Description="software engineering",Auther=new Auther()
                }
            };
        }
        public void Add(Book entity)
        {
            books.Add(entity);
        }

        public void Delete(int id)
        {
            var book = Find(id);
            books.Remove(book);
        }

        public Book Find(int id)
        {
            var book = books.SingleOrDefault(books => books.Id == id);
            return book;
        }

        public IList<Book> List()
        {
            return books;
        }

        public void Update(int id,Book newBook)
        {
            var book = Find( id);
            book.Title = newBook.Title;
            book.Description = newBook.Description;
            book.Auther = newBook.Auther;
        }
    }
}
