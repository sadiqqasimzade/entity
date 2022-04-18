using BookSql.DAL;
using BookSql.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookSql.Sql
{
    internal class SqlBook
    {
        public static void GetAll()
        {
            using (AppDbContext sql = new AppDbContext())
            {
                List<Book> books = sql.Books.ToList();
                foreach (Book book in books)
                    foreach (var prop in book.GetType().GetProperties())
                        Console.WriteLine(prop.Name + ":" + prop.GetValue(book));
            }
        }

        public static void Update(int id)
        {
            using (AppDbContext sql = new AppDbContext())
            {
                if (FindId(id))
                {
                    Book book = sql.Books.SingleOrDefault(b => b.Id == id);
                    byte choise;
                    do
                    {
                        choise = Inputs.NumberInput<byte>("0-Exit\n1-Change Name\n2-Change Page Count\n3-Change Stock Count\n4-Change Price\n5-Change Genre\n6-Change Author\n7-Change Publisher\nChoise", 0);
                        switch (choise)
                        {
                            case 0: break;
                            case 1:
                                book.Name = Console.ReadLine();
                                sql.SaveChanges();
                                break;
                            case 2:
                                book.PageCount = Inputs.NumberInput<int>("Page Count", 0);
                                sql.SaveChanges();
                                break;
                            case 3:
                                book.StockCount = Inputs.NumberInput<int>("Stock Count", 0);
                                sql.SaveChanges();
                                break;
                            case 4:
                                book.Price = Inputs.NumberInput<decimal>("Price", 0);
                                sql.SaveChanges();
                                break;
                            case 5:
                                do
                                {
                                    choise = Inputs.NumberInput<byte>("0-Exit\n1-Add Genre\n2-Remove Genre\n3-Update\nChoise", 0);
                                    switch (choise)
                                    {
                                        case 0:
                                            
                                            break;
                                        case 1:
                                            SqlBookGenre.AddGenre(Inputs.StringInput("Genre Name"));

                                            sql.SaveChanges();
                                            break;
                                        case 2:

                                            sql.SaveChanges();
                                            break;
                                        default:
                                            Console.WriteLine("Wrong Input");
                                            break;
                                    }
                                } while (choise != 0);
                                break;
                            case 6:
                                do
                                {
                                    choise = Inputs.NumberInput<byte>("0-Exit\n1-Add Author\n2-Remove Author", 0);
                                    switch (choise)
                                    {
                                        case 0: break;
                                        case 1:

                                            sql.SaveChanges();
                                            break;
                                        case 2:

                                            sql.SaveChanges();
                                            break;
                                        default:
                                            Console.WriteLine("Wrong Input");
                                            break;
                                    }
                                } while (choise != 0);
                                break;
                            case 7:
                                do
                                {
                                    choise = Inputs.NumberInput<byte>("0-Exit\n1-Add Publisher\n2-Remove Publisher", 0);
                                    switch (choise)
                                    {
                                        case 0: break;
                                        case 1:

                                            sql.SaveChanges();
                                            break;
                                        case 2:

                                            sql.SaveChanges();
                                            break;
                                        default:
                                            Console.WriteLine("Wrong Input");
                                            break;
                                    }
                                } while (choise != 0);
                                break;
                            default:
                                Console.WriteLine("Wrong Input");
                                break;
                        }
                    } while (choise != 0);
                }
            }
        }

        public static void Create()
        {
            using (AppDbContext sql = new AppDbContext())
            {
                Book book = new Book();
                Inputs.UpdateWithReflection(ref book);
                if (sql.Books.Any(b => b.Name == book.Name))
                {
                    Console.WriteLine("Already Created"); return;
                }
                sql.Add(book);
                sql.SaveChanges();
            }
        }

        public static void Remove(int id)
        {
            using (AppDbContext sql = new AppDbContext())
            {
                Book book = sql.Books.Find(id);
                sql.Books.Remove(book);
                sql.SaveChanges();
            }
        }

        public static void Sell(string bookname,int count)
        {
            using (AppDbContext sql = new AppDbContext())
            {
                if (!sql.Books.Any(b => b.Name==bookname)) return;
                Book book = sql.Books.SingleOrDefault(b => b.Name == bookname);
                if (book.StockCount > count)
                {
                    book.StockCount-=count;
                    AddIntoSoldBook(book.Id,count);
                    sql.SaveChanges();
                }
                else Console.WriteLine("No Books Available");
            }
        }

        public static void AddIntoSoldBook(int id,int count)
        {
            SoldBook soldbook = new SoldBook();
            using (AppDbContext sql = new AppDbContext())
            {
                soldbook.bookId = id;
                soldbook.Count = count;
                soldbook.DateTime= DateTime.Now;
                sql.Add(soldbook);
                sql.SaveChanges();
            }
        }

        static bool FindId(int id)
        {
            using (AppDbContext sql = new AppDbContext())
            {
                if (!sql.Books.Any(b => b.Id == id)) return false;
                return true;
            }
        }

        public static void AddPublisherBook(string publiName, string bookName)
        {
            using (AppDbContext sql = new AppDbContext())
            {
                
            }
        }
    }
}
