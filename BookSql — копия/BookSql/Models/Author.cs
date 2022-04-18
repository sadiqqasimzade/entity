using System;
using System.Collections.Generic;
using System.Text;

namespace BookSql.Models
{
    internal class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public List<BookAuthor> bookAuthors { get; set; }
    }
}
