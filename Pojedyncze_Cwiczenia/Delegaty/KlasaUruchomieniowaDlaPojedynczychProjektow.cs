﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using System.Xml.Linq;
using static Pojedyncze_Cwiczenia.Delegaty.DelegatyCwiczenia11;


namespace Pojedyncze_Cwiczenia.Delegaty
{
    public static class KlasaUruchomieniowaDlaPojedynczychProjektow
    {
        public static void Main()
        {
            //KlasaUruchomieniowaDlaPojedynczychProjektow klasaUruchomieniowaDlaPojedynczychProjektow = new KlasaUruchomieniowaDlaPojedynczychProjektow();
            DelgatyCwiczenia1 delgatyCwiczenia1 = new DelgatyCwiczenia1();
            delgatyCwiczenia1.PierwszeCwiczenia();

            DelegatyCwiczenia2 delegatyCwiczenia2 = new DelegatyCwiczenia2();
            delegatyCwiczenia2.DrugieCwiczenie();

            DelegatyCwiczenia3 delegatyCwiczenia3 = new DelegatyCwiczenia3();
            delegatyCwiczenia3.TrzecieCwiczenie();

            DelegatyCwiczenia4 delegatyCwiczenia4 = new DelegatyCwiczenia4();
            delegatyCwiczenia4.CzwarteCwiczenie();
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
    //---------------------------------------------------------------------------- TRZECIE ZADANIE __ POCZĄTEK
    public class DelegatyCwiczenia3
    {
        public void TrzecieCwiczenie()
        {
            List<Product2> products = new List<Product2>
            {
                new Product2 { Name = "Laptop", Category = "Electronics", Price = 1200.50, Rating = 4.8 },
                new Product2 { Name = "Smartphone", Category = "Electronics", Price = 800.99, Rating = 4.5 },
                new Product2 { Name = "Tablet", Category = "Electronics", Price = 300.75, Rating = 4.1 },
                new Product2 { Name = "Headphones", Category = "Accessories", Price = 150.00, Rating = 4.2 },
                new Product2 { Name = "Keyboard", Category = "Accessories", Price = 99.99, Rating = 4.4 }
            };

            Func<List<Product2>, string, List<Product2>> actionDlaPierwszejMedoty = (products, categoty) => FilterByCategory(products, categoty);

            // Filtrowanie produktów według kategorii
            List<Product2> electronics = FilterByCategory(products, "Electronics");
            Console.WriteLine("Electronics:");
            PrintProducts(electronics);


            Func<List<Product2>, List<Product2>> product2s = (products) => SortByPriceAscending(products);

            // Sortowanie produktów według ceny rosnąco
            List<Product2> sortedByPrice = SortByPriceAscending(products);
            Console.WriteLine("\nProducts sorted by price:");
            PrintProducts(sortedByPrice);



            Func<List<Product2>, double> product3 = (products) => CalculateAveragePrice(products);
            // Obliczanie średniej ceny produktów
            double averagePrice = CalculateAveragePrice(products);
            Console.WriteLine($"\nAverage Price: {averagePrice}");

            Func<List<Product2>, List<Product2>> prodct4 = (products) => FilterHighRatedProducts(products);

            // Filtrowanie produktów z wysoką oceną
            List<Product2> highRatedProducts = FilterHighRatedProducts(products);
            Console.WriteLine("\nHighly Rated Products:");
            PrintProducts(highRatedProducts);

            Action<List<Product2>> product4 = (products) => PrintAllProducts(products);
            // Wydrukowanie szczegółów wszystkich produktów
            Console.WriteLine("\nAll Products:");
            PrintAllProducts(products);

            Console.ReadKey();
        }

        static List<Product2> FilterByCategory(List<Product2> products, string category)
        {
            List<Product2> result = new List<Product2>();
            foreach (var product in products)
            {
                if (product.Category == category)
                {
                    result.Add(product);
                }
            }
            return result;
        }

        static List<Product2> SortByPriceAscending(List<Product2> products)
        {
            List<Product2> sortedProducts = new List<Product2>(products);
            sortedProducts.Sort((p1, p2) => p1.Price.CompareTo(p2.Price));
            return sortedProducts;
        }

        static double CalculateAveragePrice(List<Product2> products)
        {
            double total = 0;
            foreach (var product in products)
            {
                total += product.Price;
            }
            return total / products.Count;
        }
        static List<Product2> FilterHighRatedProducts(List<Product2> products)
        {
            List<Product2> result = new List<Product2>();
            foreach (var product in products)
            {
                if (product.Rating > 4.5)
                {
                    result.Add(product);
                }
            }
            return result;
        }

        static void PrintAllProducts(List<Product2> products)
        {
            foreach (var product in products)
            {
                Console.WriteLine($"Name: {product.Name}, Category: {product.Category}, Price: {product.Price}, Rating: {product.Rating}");
            }
        }

        static void PrintProducts(List<Product2> products)
        {
            foreach (var product in products)
            {
                Console.WriteLine($"Name: {product.Name}, Category: {product.Category}, Price: {product.Price}, Rating: {product.Rating}");
            }
        }
    }
    class Product2
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public double Price { get; set; }
        public double Rating { get; set; }
    }

    public delegate List<int> delegateCwCztery(List<int> n);
    public class DelegatyCwiczenia4
    {
        public void CzwarteCwiczenie()
        {
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };

            delegateCwCztery delegateCwCztery = FilterEvenNumbers;
            var del4Cw = delegateCwCztery(numbers);

            Console.WriteLine("Parzyste liczby:");
            foreach (var number in del4Cw)
            {
                Console.WriteLine(number);
            }

            Func<List<int>, int> delegatMetodySumNumbers = SumNumbers;
            // Zwykła metoda do sumowania liczb
            int sum = delegatMetodySumNumbers(numbers);
            Console.WriteLine($"Suma liczb: {sum}");

            // Zwykła metoda do drukowania liczb
            PrintNumbers(numbers);
        }

        // Metoda filtrowania liczb parzystych
        static List<int> FilterEvenNumbers(List<int> numbers)
        {
            List<int> evenNumbers = new List<int>();
            foreach (var number in numbers)
            {
                if (number % 2 == 0)
                {
                    evenNumbers.Add(number);
                }
            }
            return evenNumbers;
        }

        static int SumNumbers(List<int> numbers)
        {
            int sum = 0;
            foreach (var number in numbers)
            {
                sum += number;
            }
            return sum;
        }

        static void PrintNumbers(List<int> numbers)
        {
            Console.WriteLine("Liczby:");
            foreach (var number in numbers)
            {
                Console.WriteLine(number);
            }
        }
    }

    // -----------------------------------------

    public delegate bool delegatDlaWarunku(int e);
    public class DelegatyCwiczenia5
    {
        public void PiateCwiczenie()
        {
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6 };

            delegatDlaWarunku delWar = GreaterThanThree;

            List<int> filteredNumbers = FilterNumbers(numbers, delWar);
            Console.WriteLine("Liczby większe niż 3:");
            foreach (var number in filteredNumbers)
            {
                Console.WriteLine(number);
            }
        }
        static bool GreaterThanThree(int number)
        {
            return number > 3;
        }
        static List<int> FilterNumbers(List<int> numbers, delegatDlaWarunku elo)
        {
            List<int> filteredNumbers = new List<int>();
            foreach (var number in numbers)
            {
                if (elo(number))
                {
                    filteredNumbers.Add(number);
                }
            }
            return filteredNumbers;
        }
    }
    public delegate int Delegat6Cwiczenia(int c);
    public class DelegatyCwiczenia6
    {
        public void SzosteCwiczenie()
        {
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };

            Delegat6Cwiczenia del6cw = DoubleValue;

            List<int> doubledNumbers = TransformNumbers(numbers, del6cw);
            Console.WriteLine("Podwojone liczby:");
            foreach (var number in doubledNumbers)
            {
                Console.WriteLine(number);
            }
        }
        static int DoubleValue(int number)
        {
            return number * 2;
        }
        static List<int> TransformNumbers(List<int> numbers, Delegat6Cwiczenia transformer)
        {
            List<int> transformedNumbers = new List<int>();
            foreach (var number in numbers)
            {
                transformedNumbers.Add(transformer(number));
            }
            return transformedNumbers;
        }
    }

    public delegate void delegatDo7cwiczenia(string e, string b);
    public class DelegatyCwiczenia7
    {
        public void SiodmeCwiczenie()
        {
            string message = "Witaj, świecie!";

            delegatDo7cwiczenia del7cw = (e, b) => PrintMessage(e, Console.WriteLine);

            PrintMessage(message, Console.WriteLine);
        }
        static void PrintMessage(string message, Action<string> printer)
        {
            printer(message);
        }
    }

    public delegate bool DlegatWarunkuCW8(string n);
    public class DelegatyCwiczenia8
    {
        public void ÓsmeCwiczenie()
        {
            List<string> names = new List<string> { "Anna", "Bob", "Charlie", "David" };

            DlegatWarunkuCW8 dlegatWarunkuCW8 = StartsWithC;

            List<string> filteredNames = FilterNames(names, dlegatWarunkuCW8);
            Console.WriteLine("Imiona zaczynające się na 'C':");
            foreach (var name in filteredNames)
            {
                Console.WriteLine(name);
            }

        }
        static bool StartsWithC(string name)
        {
            return name.StartsWith("C");
        }

        static List<string> FilterNames(List<string> names, DlegatWarunkuCW8 dlegatWarunku)
        {
            List<string> filteredNames = new List<string>();
            foreach (var name in names)
            {
                if (dlegatWarunku(name))
                {
                    filteredNames.Add(name);
                }
            }
            return filteredNames;
        }
    }
    public delegate int delegateCwDziewiec(int y, int elo);
    public class DelegatyCwiczenia9
    {
        public void dziewiateCwiczenie()
        {
            List<int> numbers = new List<int> { 5, 3, 8, 1, 2 };

            delegateCwDziewiec del9 = CompareDescending;


            numbers.Sort(new Comparison<int>(del9));
            Console.WriteLine("Posortowane liczby malejąco:");
            foreach (var number in numbers)
            {
                Console.WriteLine(number);
            }
            static int CompareDescending(int x, int y)
            {
                return y.CompareTo(x);
            }
        }
    }

    public delegate double DelegatZCwDZiesiatego(double h, double e);
    public class DelegatyCwiczenia10
    {
        public void dziesiateCwiczenie()
        {
            double a = 5;
            double b = 3;

            DelegatZCwDZiesiatego delegatZCwDZiesiatego1 = Subtract;
            delegatZCwDZiesiatego1 += Add;


            // Dodawanie
            double result = PerformOperation(a, b, Add);
            Console.WriteLine($"Dodawanie: {a} + {b} = {result}");

            // Odejmowanie
            result = PerformOperation(a, b, delegatZCwDZiesiatego1);
            Console.WriteLine($"Odejmowanie: {a} - {b} = {result}");
        }
        static double Add(double x, double y)
        {
            return x + y;
        }

        static double Subtract(double x, double y)
        {
            return x - y;
        }

        static double PerformOperation(double x, double y, DelegatZCwDZiesiatego delegatZCwDZiesiategeee)
        {
            return delegatZCwDZiesiategeee(x, y);
        }
    }

    public class DelegatyCwiczenia11
    {
        public void jedenasteCwiczenie()
        {
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };

            Func<int, int> funcZadanie11 = Square;

            List<int> squaredNumbers = ProcessCollection(numbers, funcZadanie11);
            Console.WriteLine("Liczby podniesione do kwadratu:");
            foreach (var number in squaredNumbers)
            {
                Console.WriteLine(number);
            }
            static int Square(int number)
            {
                return number * number;
            }

            static List<int> ProcessCollection(List<int> collection, Func<int, int> processor)
            {
                List<int> result = new List<int>();
                foreach (var item in collection)
                {
                    result.Add(processor(item));
                }
                return result;
            }
        }

        public class Dlegaty12Cwiczenie
        {
            public void dwunateCwiczenie()
            {

                List<string> passwords = new List<string> { "password", "123456", "abcdef", "123abc" };

                Predicate<string> ddelegateCwiczenie13 = IsValidPassword;

                List<string> validPasswords = ValidateTexts(passwords, IsValidPassword);
                Console.WriteLine("Poprawne hasła:");
                foreach (var password in validPasswords)
                {
                    Console.WriteLine(password);
                }
            }
            static bool IsValidPassword(string password)
            {
                return password.Length >= 6;
            }

            static List<string> ValidateTexts(List<string> texts, Predicate<string> validator)
            {
                List<string> result = new List<string>();
                foreach (var text in texts)
                {
                    if (validator(text))
                    {
                        result.Add(text);
                    }
                }
                return result;
            }
        }

        public class trzynasteCwiczenieDelegate
        {
            public void TrzynasteCwiczenie()
            {
                List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };

                Func<int, int> funcZadanie = Square;

                List<int> squaredNumbers = ProcessCollection(numbers, funcZadanie);
                Console.WriteLine("Liczby podniesione do kwadratu:");
                foreach (var number in squaredNumbers)
                {
                    Console.WriteLine(number);
                }
            }
            public static int Square(int number)
            {
                return number * number;
            }

            public static List<int> ProcessCollection(List<int> collection, Func<int, int> processor)
            {
                List<int> result = new List<int>();
                foreach (var item in collection)
                {
                    result.Add(processor(item));
                }
                return result;

            }
        }

        public class czternateCwiczenieDelegate
        {
            public void czternasteCwiczenie()
            {
                List<string> words = new List<string> { "apple", "banana", "cherry", "date", "elderberry" };

                Func<string, string> delegatFuncDlaZadani14 = DuzaLitera;

                List<string> uppercasedWords = UppercaseWords(words, delegatFuncDlaZadani14);
                Console.WriteLine("Słowa zapisane wielkimi literami:");
                foreach (var word in uppercasedWords)
                {
                    Console.WriteLine(word);
                }

                static List<string> UppercaseWords(List<string> collection, Func<string, string> elo)
                {
                    List<string> result = new List<string>();
                    foreach (var item in collection)
                    {
                        result.Add(elo(item));
                    }
                    return result;
                }
            }
            public string DuzaLitera(string wyraz)
            {
                return wyraz.ToUpper();
            }
        }
        public class pietnascieCwiczenieDelegate
        {
            public void pietnasteCwiczenieCwiczenie()
            {
                List<double> temperatures = new List<double> { 32.0, 45.5, 50.3, 60.2, 72.4 };

                List<double> convertedTemperatures = ConvertTemperaturesToCelsius(temperatures);
                Console.WriteLine("Temperatury w stopniach Celsjusza:");
                foreach (var temp in convertedTemperatures)
                {
                    Console.WriteLine(temp);
                }
            }
            static List<double> ConvertTemperaturesToCelsius(List<double> collection)
            {
                List<double> result = new List<double>();
                foreach (var item in collection)
                {
                    result.Add((item - 32) * 5 / 9);
                }
                return result;
            }
        }

        public delegate double DlelegatDlaDodawania14(double a);
        public class SzesnasteCwiczenieDelegate
        {
            public void pietnasteCwiczenie()
            {
                List<double> temperatures = new List<double> { 32.0, 45.5, 50.3, 60.2, 72.4 };

                DlelegatDlaDodawania14 dlelegatDlaDodawania = MechanizmOdejmowania14;

                List<double> convertedTemperatures = ConvertTemperaturesToCelsius(temperatures, dlelegatDlaDodawania);
                Console.WriteLine("Temperatury w stopniach Celsjusza:");
                foreach (var temp in convertedTemperatures)
                {
                    Console.WriteLine(temp);
                }
            }
            static List<double> ConvertTemperaturesToCelsius(List<double> collection, DlelegatDlaDodawania14 dlelegatDlaDodawania)
            {
                List<double> result = new List<double>();
                foreach (var item in collection)
                {
                    result.Add((item - 32) * 5 / 9);
                    result.Add(dlelegatDlaDodawania(item));
                }
                return result;
            }

            public double MechanizmOdejmowania14(double item)
            {
                return (item - 32) * 5 / 9;
            }
        }
        //----------------- KOLEJNE ĆWICZENIE

        delegate string Delegatcw17PersonElementry(Person e);
        public class SiedemnasteCwiczenieDelegate
        {
            public void SiedemnastyCwiczenieCwiczenie()
            {
                List<Person> people = new List<Person>
                {
                    new Person { Name = "John", Age = 30 },
                    new Person { Name = "Jane", Age = 25 },
                    new Person { Name = "Tom", Age = 40 },
                    new Person { Name = "Lucy", Age = 35 }
                };

                Delegatcw17PersonElementry delegatcw17PersonElementry = DodawanieDla17Zadania;

                List<string> names = ExtractNames(people, delegatcw17PersonElementry);
                Console.WriteLine("Imiona:");
                foreach (var name in names)
                {
                    Console.WriteLine(name);
                }
            }
            static List<string> ExtractNames(List<Person> collection, Delegatcw17PersonElementry delegatcw17PersonElementry)
            {
                List<string> result = new List<string>();
                foreach (var item in collection)
                {
                    result.Add(delegatcw17PersonElementry(item));
                }
                return result;
            }

            public string DodawanieDla17Zadania(Person item)
            {
                return item.Name;
            }
        }
        public class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }


        // Koleje Ćwiczenie-------------------



        public delegate Person DelegatDo17Zadania();
        public delegate double DelegatDo17Zadania2();
        public class OsiemnastyCwiczenieDelegate
        {
            public void OsiemnastyCwiczenieCwiczenie()
            {
                List<Product> products = new List<Product>
                {
                    new Product { Name = "Laptop", Price = 1200.00, Category = "Electronics" },
                    new Product { Name = "Smartphone", Price = 800.00, Category = "Electronics" },
                    new Product { Name = "Bread", Price = 2.50, Category = "Groceries" },
                    new Product { Name = "Milk", Price = 1.20, Category = "Groceries" },
                    new Product { Name = "Headphones", Price = 150.00, Category = "Electronics" }
                };

                // Filtracja
                List<Product> filteredProducts = FilterElectronics(products);
                // Przetwarzanie
                List<double> productPrices = ExtractPrices(filteredProducts);
                // Sortowanie
                List<Product> sortedProducts = SortByPrice(filteredProducts);

                Console.WriteLine("Produkty z kategorii Electronics:");
                foreach (var product in sortedProducts)
                {
                    Console.WriteLine($"{product.Name} - {product.Price:C}");
                }
            }

            static List<Product> FilterElectronics(List<Product> collection)
            {
                List<Product> result = new List<Product>();
                foreach (var item in collection)
                {
                    if (item.Category == "Electronics")
                    {
                        result.Add(item);
                    }
                }
                return result;
            }

            static List<double> ExtractPrices(List<Product> collection)
            {
                List<double> result = new List<double>();
                foreach (var item in collection)
                {
                    result.Add(item.Price);
                }
                return result;
            }

            static List<Product> SortByPrice(List<Product> collection)
            {
                List<Product> sortedList = new List<Product>(collection);
                sortedList.Sort((x, y) => x.Price.CompareTo(y.Price));
                return sortedList;
            }
        }

        public class Product
        {
            public string Name { get; set; }
            public double Price { get; set; }
            public string Category { get; set; }
        }
    }
}


