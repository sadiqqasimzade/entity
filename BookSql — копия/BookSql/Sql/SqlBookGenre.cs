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
        public static void Create()
        {
            using (AppDbContext sql = new AppDbContext())
            {
                BookGenre bookGenre = new BookGenre();
                bookGenre.Book.Name = Inputs.StringInput("KitabName");
                bookGenre.Genre.Name = Inputs.StringInput("Genre");
                bookGenre.BookId = SqlBookGenre.FindBookIdWithName(bookGenre.Book.Name);
                bookGenre.GenreId = SqlBookGenre.FindGenreIdWithName(bookGenre.Genre.Name);
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

        public static int FindBookIdWithName(string name)
        {
            using (AppDbContext sql = new AppDbContext())
            {
                List<Book> books = sql.Books.ToList();
                bool isOk = false;
                foreach (var item in books)
                {
                    if (item.Name != name)
                    {
                        isOk = true; break;
                    }
                }
                if (isOk)
                {
                    if (!sql.Books.Any(p => p.Name == name))
                    {
                        Console.WriteLine("There is no book like this name");
                    }
                    Book book = sql.Books.SingleOrDefault(b => b.Name == name);
                    return book.Id;
                }
                else Console.WriteLine("The book by this name already exists"); return -1;
            }
        }

        public static int FindGenreIdWithName(string name)
        {
            using (AppDbContext sql = new AppDbContext())
            {
                List<Genre> genres = sql.Genres.ToList();
                bool isOk = false;
                foreach (var item in genres)
                {
                    if (item.Name != name)
                    {
                        isOk = true; break;
                    }
                }
                if (isOk)
                {
                    if (!sql.Genres.Any(p => p.Name == name))
                    {
                        Console.WriteLine("There is no genre like this name");
                    }
                    Genre genre = sql.Genres.SingleOrDefault(p => p.Name == name);
                    return genre.Id;
                }
                else Console.WriteLine("The genre by this name already exists"); return -1;
            }
        }
    }
}

