using BookCore.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookCore.ViewModels
{
    public class BookAuthorViewModel
    {

        public int BookId { get; set; }
        public string Title { get; set; }
        public string Descr { get; set; }
        public int AutherId { get; set; }
        public List<Auther>Authors { get; set; }
        public IFormFile File { get; set; }
    }
}
