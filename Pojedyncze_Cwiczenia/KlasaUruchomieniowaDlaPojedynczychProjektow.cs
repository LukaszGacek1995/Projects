using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Pojedyncze_Cwiczenia
{
    public static class KlasaUruchomieniowaDlaPojedynczychProjektow
    {
        public static void Main()
        {
            //KlasaUruchomieniowaDlaPojedynczychProjektow klasaUruchomieniowaDlaPojedynczychProjektow = new KlasaUruchomieniowaDlaPojedynczychProjektow();
            DelgatyCwiczenia1 delgatyCwiczenia1 = new DelgatyCwiczenia1();
            delgatyCwiczenia1.PierwszeCwiczenia();
        }
    }

    delegate List<Book> Delegat1(List<Book> a, double b);
    delegate List<Book> Delegat2(List<Book> c);
    delegate double Delegat3(List<Book> c);


    public class DelgatyCwiczenia1
    {
        public void PierwszeCwiczenia()
        {
            List<Book> books = new List<Book>
            {
                new Book { Title = "C# in Depth", Author = "Jon Skeet", Rating = 4.7 },
                new Book { Title = "Clean Code", Author = "Robert C. Martin", Rating = 4.5 },
                new Book { Title = "Design Patterns", Author = "Erich Gamma", Rating = 4.3 },
                new Book { Title = "Domain-Driven Design", Author = "Eric Evans", Rating = 4.1 },
                new Book { Title = "Refactoring", Author = "Martin Fowler", Rating = 4.6 }
            };
            Delegat1 del1 = FilterHighRatedBooks;
            var element = del1(books, 4.5);
            Console.WriteLine("Highly Rated Books:");
            PrintBooks(element);


            Delegat2 del2 = SortByTitle;
            var element2 = del2(books);
            Console.WriteLine("\nBooks sorted by title:");
            PrintBooks(element2);


            Delegat3 del3 = CalculateAverageRating;
            var element3 = del3(books);
            Console.WriteLine($"\nAverage Rating: {element3}");

            Console.ReadKey();
        }

        static List<Book> FilterHighRatedBooks(List<Book> books, double ratingThreshold)
        {
            return books.Where(b => b.Rating > ratingThreshold).ToList();
        }

        static List<Book> SortByTitle(List<Book> books)
        {
            return books.OrderBy(b => b.Title).ToList();
        }

        static double CalculateAverageRating(List<Book> books)
        {
            return books.Average(b => b.Rating);
        }

        static void PrintBooks(List<Book> books)
        {
            foreach (var book in books)
            {
                Console.WriteLine($"Title: {book.Title}, Author: {book.Author}, Rating: {book.Rating}");
            }
        }
    }

    class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public double Rating { get; set; }
    }


    //------------------------------------------------------DRUGIER ZADANIE ___ POCZĄTEK

    delegate List<Product> DelegatPierwszyZdrugiegoZadania(List<Product> a, string b);
    delegate List<Product> DelegatDrugiZdrugiegoZadania(List<Product> c);
    delegate double DelegatTrzeci(List<Product> d);
    public class DelegatyCwiczenia2
    {
        public void DrugieCwiczenie()
        {
            List<Product> products = new List<Product>
            {
                new Product { Name = "Laptop", Category = "Electronics", Price = 1200.50, Rating = 4.8 },
                new Product { Name = "Smartphone", Category = "Electronics", Price = 800.99, Rating = 4.5 },
                new Product { Name = "Tablet", Category = "Electronics", Price = 300.75, Rating = 4.1 },
                new Product { Name = "Headphones", Category = "Accessories", Price = 150.00, Rating = 4.2 },
                new Product { Name = "Keyboard", Category = "Accessories", Price = 99.99, Rating = 4.4 }
            };

            DelegatPierwszyZdrugiegoZadania delegatPierwszyZdrugiegoZadania = FilterByCategory;
            var pierwszyDelegat = delegatPierwszyZdrugiegoZadania(products, "Electronics");
            PrintProducts(pierwszyDelegat);


            DelegatDrugiZdrugiegoZadania delegatDrugiZdrugiegoZadania = SortByPriceAscending;
            var drugiDelegat = delegatDrugiZdrugiegoZadania(products);
            Console.WriteLine("\nProducts sorted by price:");
            PrintProducts(drugiDelegat);

            DelegatTrzeci trzeciDelegat = CalculateAveragePrice;
            var trzeci = trzeciDelegat(products);
            Console.WriteLine($"\nAverage Price: {trzeci}");

            // Grupowanie produktów według kategorii
            var groupedByCategory = GroupByCategory(products);
            Console.WriteLine("\nProducts grouped by category:");
            foreach (var group in groupedByCategory)
            {
                Console.WriteLine($"Category: {group.Key}");
                PrintProducts(group.ToList());
            }

            Console.ReadKey();
        }
        static List<Product> FilterByCategory(List<Product> products, string category)
        {
            return products.Where(p => p.Category == category).ToList();
        }

        static List<Product> SortByPriceAscending(List<Product> products)
        {
            return products.OrderBy(p => p.Price).ToList();
        }

        static double CalculateAveragePrice(List<Product> products)
        {
            return products.Average(p => p.Price);
        }

        static IEnumerable<IGrouping<string, Product>> GroupByCategory(List<Product> products)
        {
            return products.GroupBy(p => p.Category);
        }

        static void PrintProducts(List<Product> products)
        {
            foreach (var product in products)
            {
                Console.WriteLine($"Name: {product.Name}, Category: {product.Category}, Price: {product.Price}, Rating: {product.Rating}");
            }
        }
    }
    class Product
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public double Price { get; set; }
        public double Rating { get; set; }
    }
}
