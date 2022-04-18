using BookSql.DAL;
using System;
using System.Collections.Generic;
using System.Text;
using BookSql.Models;
using System.Linq;

namespace BookSql.Sql
{
    internal class SqlBookAuthor
    {
        public static void Create(Author author,Book book)
        {
            using (AppDbContext sql = new AppDbContext())
            {
                BookAuthor bookAuthor = new BookAuthor();
                bookAuthor.Author = author;
                bookAuthor.Book = book;
                sql.Add(bookAuthor);
                sql.SaveChanges();
            }

        }

        public static void GetAll()
        {
            using (AppDbContext sql = new AppDbContext())
            {
                List<BookAuthor> bookAuthors = sql.BookAuthors.ToList();
                foreach (BookAuthor bookAuthor in bookAuthors)
                    foreach (var prop in bookAuthor.GetType().GetProperties())
                        Console.WriteLine(prop.Name + ":" + prop.GetValue(bookAuthor));
            }
        }

        public static void Update(int id)
        {

        }


        public static void Remove(int id)
        {
            using (AppDbContext sql = new AppDbContext())
            {
                BookAuthor bookAuthor = sql.BookAuthors.FirstOrDefault(x => x.Id == id);
                sql.BookAuthors.Remove(bookAuthor);
                sql.SaveChanges();
            }
        }
    }
}
