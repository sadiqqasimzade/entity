using System;
using System.Collections.Generic;
using System.Text;

namespace BookSql.Models
{
    internal class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PageCount { get; set; }
        public int StockCount { get; set; }
        public decimal Price { get; set; }


        public List<BookGenre> GenreSet { get; set; }
        public List<BookAuthor> AuthorSet { get; set; }
        public List<BookPublisher> PublisherSet { get; set; }

    }
}
