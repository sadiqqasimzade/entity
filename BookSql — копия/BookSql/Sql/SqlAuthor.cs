using BookSql.DAL;
using BookSql.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookSql.Sql
{
    internal class SqlAuthor
    {
        public static void Create()
        {
            using (AppDbContext sql = new AppDbContext())
            {
                Author author = new Author ();
                Inputs.UpdateWithReflection(ref author);

                sql.Add(author);
                sql.SaveChanges();
            }
        }

        public static void GetAll()
        {
            using (AppDbContext sql = new AppDbContext())
            {
                List<Author> authors = sql.Authors.ToList();
                foreach (Author author in authors)
                    foreach (var prop in author.GetType().GetProperties())
                        Console.WriteLine(prop.Name + ":" + prop.GetValue(author));
            }
        }

        public static void Update(int id)
        {
            using (AppDbContext sql = new AppDbContext())
            {
                if (!sql.Authors.Any(p => p.Id == id)) return;
                Author author = sql.Authors.Find(id);
                byte choice;
                do
                {
                    choice = Inputs.NumberInput<byte>("0-Exit\n1-Change Name\n2-Change Surname\nChoice:", 0);
                    switch (choice)
                    {
                        case 0:break;
                        case 1: author.Name = Inputs.StringInput("Name");
                            break;
                        case 2: author.Surname = Inputs.StringInput("Surname");
                            break;
                        default:
                            Console.WriteLine("Wrong Input");
                            break;
                    }
                } while (choice!=0);

                sql.SaveChanges();
            }
        }


        public static void Remove(int id)
        {
            using (AppDbContext sql = new AppDbContext())
            {
                Author author = sql.Authors.FirstOrDefault(x => x.Id == id);
                sql.Authors.Remove(author);
                sql.SaveChanges();
            }
        }


        
    }
}
