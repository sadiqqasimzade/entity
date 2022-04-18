using BookSql.DAL;
using System;
using BookSql.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using BookSql.Sql;

namespace BookSql
{
    internal class Program
    {
        static void Main(string[] args)
        {
            byte choise;

            do
            {
                choise =Inputs.NumberInput<byte>("0-Exit\n1-Work With Authors\n2-Work With Book\n3-Work With BookAuthors\n4-Work With Book Genres\n5-Work With Book Publishers\n6-Work With Genre\n7-Work With Publishers\n8-Work With Sold Books\nChoise", 0);
                switch (choise)
                {
                    case 0: break;
                    case 1:
                        Inputs.WorkWithAuthors();
                        break;
                    case 2:
                        Inputs.WorkWithBook();
                        break;
                    case 3:
                        Inputs.WorkWithBookAuthors();
                        break;
                    case 4:
                        Inputs.WorkWithBookGenres();
                        break;
                    case 5:
                        Inputs.WorkWithBookPublishers();
                        break;
                    case 6:
                        Inputs.WorkWithGenre();
                        break;
                    case 7:
                        Inputs.WorkWithPublishers();
                        break;
                    case 8:
                        Inputs.WorkWithSoldBooks();
                        break;
                    default:
                        Console.WriteLine("Wrong Input");
                        break;
                }
            } while (choise != 0);
        }

    }

       
}
