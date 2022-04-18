using System;
using System.Collections.Generic;
using System.Text;

namespace BookSql.Models
{
    internal class BookGenre
    {
        public int Id { get; set; }

        public int GenreId { get; set; }

        public int BookId { get; set; }
        public Genre Genre { get; set; }    
        public Book Book { get; set; }

    }
}
