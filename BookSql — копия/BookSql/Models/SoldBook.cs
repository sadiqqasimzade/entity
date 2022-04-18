using System;
using System.Collections.Generic;
using System.Text;

namespace BookSql.Models
{
    internal class SoldBook
    {
        public int Id { get; set; }
        public Book book { get; set; }
        public int bookId { get; set; }
        public int Count { get; set; }
        public DateTime DateTime { get; set; }

    }
}
