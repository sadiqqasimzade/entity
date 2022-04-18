using BookSql.DAL;
using BookSql.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookSql.Sql
{
    internal class SqlBookGenre
    {
        public static void Create(Genre genre, Book book)
        {
            using (AppDbContext sql = new AppDbContext())
            {
                BookGenre bookGenre = new BookGenre();
                bookGenre.Genre = genre;
                bookGenre.Book = book;
                sql.Add(bookGenre);
                sql.SaveChanges();
            }
        }

        public static void GetAll()
        {
            using (AppDbContext sql = new AppDbContext())
            {
                List<BookGenre> bookGenres = sql.BookGenres.ToList();
                foreach (BookGenre bookGenre in bookGenres)
                    foreach (var prop in bookGenre.GetType().GetProperties())
                        Console.WriteLine(prop.Name + ":" + prop.GetValue(bookGenre));
            }
        }

        public static void Update(int id)
        {

        }


        public static void Remove(int id)
        {
            using (AppDbContext sql = new AppDbContext())
            {
                BookGenre bookGenre = sql.BookGenres.FirstOrDefault(x => x.Id == id);
                sql.BookGenres.Remove(bookGenre);
                sql.SaveChanges();
            }
        }

        public static void AddGenre(string genrename)
        {
            using (AppDbContext sql = new AppDbContext())
            {
               
                BookGenre bookGenre = sql.BookGenres.Include(bg => bg.Genre).ThenInclude(g => g.Name).SingleOrDefault(bg => bg.Genre.Name != genrename);
                sql.BookGenres.Add(bookGenre);
                sql.SaveChanges();
            }
        }
    }
}

