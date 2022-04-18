using System;
using System.Collections.Generic;
using System.Text;

namespace BookSql.Models
{
    internal class Publisher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<BookPublisher> BookPublishers { get; set; }
    }
}
