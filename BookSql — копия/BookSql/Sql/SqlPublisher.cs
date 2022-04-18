using BookSql.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BookSql.Models;

namespace BookSql.Sql
{
    internal class SqlPublisher
    {
        public static void Create()
        {
            using (AppDbContext sql = new AppDbContext())
            {
                Publisher publisher = new Publisher();
                Inputs.UpdateWithReflection(ref publisher);
                if (sql.Publisher.Any(p => p.Name == publisher.Name))
                {
                    Console.WriteLine("Already Exsists"); return;
                }
                sql.Add(publisher);
                sql.SaveChanges();
            }
        }

        public static void GetAll()
        {
            using (AppDbContext sql = new AppDbContext())
            {
                List<Publisher> publishers = sql.Publisher.ToList();
                foreach (Publisher publisher in publishers)
                    foreach (var prop in publisher.GetType().GetProperties())
                        Console.WriteLine(prop.Name + ":" + prop.GetValue(publisher));
            }
        }

        public static void Update(int id)
        {
            using (AppDbContext sql = new AppDbContext())
            {
                if (!sql.Publisher.Any(p => p.Id == id)) return;
                Publisher publisher = sql.Publisher.Find(id);
                Inputs.UpdateWithReflection(ref publisher);
                if (sql.Publisher.Any(p => p.Name == publisher.Name))
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
                Publisher publisher = sql.Publisher.Find(id);
                sql.Publisher.Remove(publisher);
                sql.SaveChanges();
            }
        }
    }
}
