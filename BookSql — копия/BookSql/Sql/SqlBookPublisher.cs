using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BookSql.DAL;
using BookSql.Models;
namespace BookSql.Sql
{
    internal class SqlBookPublisher
    {
        public static void Create(Publisher publisher, Book book)
        {
            using (AppDbContext sql = new AppDbContext())
            {
                BookPublisher bookPublisher = new BookPublisher();
                bookPublisher.Publisher = publisher;
                bookPublisher.Book = book;
                sql.Add(bookPublisher);
                sql.SaveChanges();
            }
        }

        public static void GetAll()
        {
            using (AppDbContext sql = new AppDbContext())
            {
                List<BookPublisher> bookPublishers = sql.BookPublisher.ToList();
                foreach (BookPublisher publisher in bookPublishers)
                    foreach (var prop in publisher.GetType().GetProperties())
                        Console.WriteLine(prop.Name + ":" + prop.GetValue(publisher));
            }
        }

        public static void Update(int id)
        {

        }


        public static void Remove(int id)
        {
            using (AppDbContext sql = new AppDbContext())
            {
                BookPublisher bookPublisher = sql.BookPublisher.FirstOrDefault(x => x.Id == id);
                sql.BookPublisher.Remove(bookPublisher);
                sql.SaveChanges();
            }
        }
    }
}
