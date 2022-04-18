using BookSql.DAL;
using System;
using BookSql.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using BookSql.Sql;


namespace BookSql
{
    internal class Inputs
    {

        //WorkWithAuthors
        public static void WorkWithAuthors()
        {
            byte choise;
            do
            {
                choise = NumberInput<byte>("0-Exit\n1-Create\n2-Remove\n3-Update\n4-GetAll\nChoise",0);
                switch (choise)
                {
                    case 0:break;
                    case 1:
                        SqlAuthor.Create();
                        break;
                    case 2:
                        SqlAuthor.Remove(NumberInput<int>("Id",0));
                        break;
                    case 3:
                        SqlAuthor.Update(NumberInput<int>("Id", 0));
                        break;
                    case 4:
                        SqlAuthor.GetAll();
                        break; 
                    default:
                        Console.WriteLine("Wrong Input");
                        break;
                }
            } while (choise!=0);
        }

        //WorkWithBook
        public static void WorkWithBook()
        {
            byte choise;
            do
            {
                choise = NumberInput<byte>("0-Exit\n1-Create\n2-Remove\n3-Update\n4-GetAll\n5-SellBook\nChoise", 0);
                switch (choise)
                {
                    case 0: break;
                    case 1:
                        SqlBook.Create();
                        break;
                    case 2:
                        SqlBook.Remove(NumberInput<int>("Id", 0));
                        break;
                    case 3:
                        SqlBook.Update(NumberInput<int>("Id", 0));
                        break;
                    case 4:
                        SqlBook.GetAll();
                        break; 
                    case 5:
                        SqlBook.Sell(StringInput("Name"), NumberInput<int>("Count", 0));
                        break;
                    default:
                        Console.WriteLine("Wrong Input");
                        break;
                }
            } while (choise != 0);
        }

        //WorkWithBookAuthors
        public static void WorkWithBookAuthors()
        {
            byte choise;
            do
            {
                choise = NumberInput<byte>("0-Exit\n1-Create\n2-Remove\n3-Update\n4-GetAll\nChoise", 0);
                switch (choise)
                {
                    case 0: break;
                    case 1: 
                        
                        break;
                    case 2:
                        SqlAuthor.Remove(NumberInput<int>("Id", 0));
                        break;
                    case 3:
                        SqlAuthor.Update(NumberInput<int>("Id", 0));
                        break;
                    case 4:
                        SqlAuthor.GetAll();
                        break;
                    default:
                        Console.WriteLine("Wrong Input");
                        break;
                }
            } while (choise != 0);
        }

        //WorkWithBookGenres
        public static void WorkWithBookGenres()
        {
            byte choise;
            do
            {
                choise = NumberInput<byte>("0-Exit\n1-Create\n2-Remove\n3-Update\n4-GetAll\nChoise", 0);
                switch (choise)
                {
                    case 0: break;
                    case 1: break;
                    case 2:
                        SqlBookGenre.Remove(NumberInput<int>("Id", 0));
                        break;
                    case 3:
                        SqlBookGenre.Update(NumberInput<int>("Id", 0));
                        break;
                    case 4:
                        SqlBookGenre.GetAll();
                        break;
                    default:
                        Console.WriteLine("Wrong Input");
                        break;
                }
            } while (choise != 0);
        }

        //WorkWithBookPublishers
        public static void WorkWithBookPublishers()
        {
            byte choise;
            do
            {
                choise = NumberInput<byte>("0-Exit\n1-Create\n2-Remove\n3-Update\n4-GetAll\nChoise", 0);
                switch (choise)
                {
                    case 0: break;
                    case 1: break;
                    case 2:
                        SqlBookPublisher.Remove(NumberInput<int>("Id", 0));
                        break;
                    case 3:
                        SqlBookPublisher.Update(NumberInput<int>("Id", 0));
                        break;
                    case 4:
                        SqlBookPublisher.GetAll();
                        break;
                    default:
                        Console.WriteLine("Wrong Input");
                        break;
                }
            } while (choise != 0);
        }

        //WorkWithGenre
        public static void WorkWithGenre()
        {
            byte choise;
            do
            {
                choise = NumberInput<byte>("0-Exit\n1-Create\n2-Remove\n3-Update\n4-GetAll\nChoise", 0);
                switch (choise)
                {
                    case 0: break;
                    case 1:
                        SqlGenre.Create();
                        break;
                    case 2:
                        SqlGenre.Remove(NumberInput<int>("Id", 0));
                        break;
                    case 3:
                        SqlGenre.Update(NumberInput<int>("Id", 0));
                        break;
                    case 4:
                        SqlGenre.GetAll();
                        break;
                    default:
                        Console.WriteLine("Wrong Input");
                        break;
                }
            } while (choise != 0);
        }

        //WorkWithPublishers
        public static void WorkWithPublishers()
        {
            byte choise;
            do
            {
                choise = NumberInput<byte>("0-Exit\n1-Create\n2-Remove\n3-Update\n4-GetAll\nChoise", 0);
                switch (choise)
                {
                    case 0: break;
                    case 1:
                        SqlPublisher.Create();
                        break;
                    case 2:
                        SqlPublisher.Remove(NumberInput<int>("Id", 0));
                        break;
                    case 3:
                        SqlPublisher.Update(NumberInput<int>("Id", 0));
                        break;
                    case 4:
                        SqlPublisher.GetAll();
                        break;
                    default:
                        Console.WriteLine("Wrong Input");
                        break;
                }
            } while (choise != 0);
        }

        //WorkWithSoldBooks
        public static void WorkWithSoldBooks()
        {
            byte choise;
            do
            {
                choise = NumberInput<byte>("0-Exit\n1-Remove\n2-GetAll\nChoise", 0);
                switch (choise)
                {
                    case 0: break;
                    case 1:
                        SqlSoldBook.Remove(NumberInput<int>("Id", 0));
                        break;
                    case 2:
                        SqlSoldBook.GetAll();
                        break;
                    default:
                        Console.WriteLine("Wrong Input");
                        break;
                }
            } while (choise != 0);
        }

        //NumberInput
        public static T NumberInput<T>(string str, decimal min = decimal.MinValue, decimal max = decimal.MaxValue)
        {
        Point:
            try
            {
                Console.Write(str + " :");
                dynamic temp = Console.ReadLine();
                temp = (T)Convert.ChangeType(temp, typeof(T));
                if (temp >= min || temp <= max)
                    return temp;
                throw new Exception("Incorrect Number");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                goto Point;
            }
        }

        //StringInput
        public static string StringInput(string str)
        {
            string name;
            do
            {
                Console.Write(str + ":");
                name = Console.ReadLine();
            } while (String.IsNullOrEmpty(name) || String.IsNullOrWhiteSpace(name));
            return name;
        }

        public static void UpdateWithReflection<T>(ref T obj)
        {
            foreach (var property in obj.GetType().GetProperties())
            {
                if (!property.Name.Contains("Id"))
                {
                    if (property.PropertyType == typeof(string)) property.SetValue(obj, Inputs.StringInput(property.Name));
                    else if (property.PropertyType == typeof(int)) property.SetValue(obj, Inputs.NumberInput<int>($"{property.Name}",0));
                    else if (property.PropertyType == typeof(double)) property.SetValue(obj, Inputs.NumberInput<double>($"{property.Name}",0));
                    else if (property.PropertyType == typeof(decimal)) property.SetValue(obj, Inputs.NumberInput<decimal>($"{property.Name}",0));
                    else if (property.PropertyType == typeof(bool)) property.SetValue(obj, Inputs.NumberInput<int>($"{property.Name}",0,1));
                    else if (property.PropertyType == typeof(byte)) property.SetValue(obj, Inputs.NumberInput<byte>($"{property.Name}", 0, 1));
                    else if (property.PropertyType == typeof(short)) property.SetValue(obj, Inputs.NumberInput<short>($"{property.Name}", 0, 1));
                    else if (property.PropertyType == typeof(float)) property.SetValue(obj, Inputs.NumberInput<float>($"{property.Name}", 0, 1));
                    else if (property.PropertyType == typeof(DateTime)) property.SetValue(obj, DateTime.Now);
                }
            }
        }
    }
}
