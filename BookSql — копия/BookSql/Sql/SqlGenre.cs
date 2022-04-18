using BookSql.DAL;
using System;
using System.Collections.Generic;
using System.Text;
using BookSql.Models;
using System.Linq;

namespace BookSql.Sql
{
    internal class SqlGenre
    {
        public static void Create()
        {
            using (AppDbContext sql = new AppDbContext())
            {
                Genre genre = new Genre();
                Inputs.UpdateWithReflection(ref genre);
                if (sql.Genres.Any(g => g.Name == genre.Name))
                {
                    Console.WriteLine("Already Exsists"); return;
                }
                sql.Add(genre);
                sql.SaveChanges();
            }
        }

        public static void GetAll()
        {
            using (AppDbContext sql = new AppDbContext())
            {
                List<Genre> genres = sql.Genres.ToList();
                foreach (Genre genre in genres)
                    foreach (var prop in genre.GetType().GetProperties())
                        Console.WriteLine(prop.Name + ":" + prop.GetValue(genre));
            }
        }

        public static void Update(int id)
        {
            using (AppDbContext sql = new AppDbContext())
            {
                if (!sql.Genres.Any(p => p.Id == id)) return;
                Genre genre = sql.Genres.Find(id);
                Inputs.UpdateWithReflection(ref genre);
                if (sql.Genres.Any(g => g.Name == genre.Name))
                {
                    Console.WriteLine("Already Exsists"); return;
                }
                sql.SaveChanges();
            }
        }


        public static void Remove(int id)
        {
            using (AppDbContext sql = new AppDbContext())
            {
                Genre genre = sql.Genres.Find(id);
                sql.Genres.Remove(genre);
                sql.SaveChanges();
            }
        }
    }
}
