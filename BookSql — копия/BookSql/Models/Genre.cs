using System;
using System.Collections.Generic;
using System.Text;

namespace BookSql.Models
{
    internal class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<BookGenre> bookGenres { get; set; }
    }
}
