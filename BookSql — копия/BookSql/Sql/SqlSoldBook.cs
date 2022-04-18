using BookSql.DAL;
using BookSql.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookSql.Sql
{
    internal class SqlSoldBook
    {


        public static void GetAll()
        {
            using (AppDbContext sql = new AppDbContext())
            {
                List<SoldBook> soldBooks = sql.SoldBooks.ToList();
                foreach (SoldBook soldBook in soldBooks)
                    foreach (var prop in soldBook.GetType().GetProperties())
                        Console.WriteLine(prop.Name + ":" + prop.GetValue(soldBook));
            }
        }


        public static void Remove(int id)
        {
            using (AppDbContext sql = new AppDbContext())
            {
                SoldBook soldBook = sql.SoldBooks.Find(id);
                sql.SoldBooks.Remove(soldBook);
                sql.SaveChanges();
            }
        }
    }
}
