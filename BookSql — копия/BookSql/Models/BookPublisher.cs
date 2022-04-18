using System;
using System.Collections.Generic;
using System.Text;

namespace BookSql.Models
{
    internal class BookPublisher
    {
        public int Id { get; set; }

        public int PublisherId { get; set; }

        public int BookId { get; set; }
        public Publisher Publisher { get; set; }
        public Book Book { get; set; }
    }
}
