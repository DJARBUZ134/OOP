using System;
using System.Collections.Generic;

namespace OOP
{
    [AttributeUsage(AttributeTargets.Class)]
    public class AuthorAttribute : Attribute
    {
        public string Name { get; }
        public AuthorAttribute(string name) { Name = name; }
    }

    public abstract class Document
    {
        protected int Id;
        protected string Title;
        public abstract string GetDocumentType();
    }

    interface IPrintable
    {
        string PrintInfo();
    }

    [Author("Иванов")]
    public class Book : Document, IPrintable
    {
        private string author = "Under";
        private int year = 1801;

        public new string Title
        {
            get { return base.Title; }
            set { base.Title = value; }
        }

        public string Author
        {
            get { return author; }
            set { author = value; }
        }

        public int Year
        {
            get { return year; }
            set
            {
                if (value <= 1800) throw new ArgumentOutOfRangeException(nameof(Year), "Год должен быть больше 1800");
                year = value;
            }
        }

        public static int TotalBooks;

        public Book()
        {
            Title = "Under";
            Author = "Under";
            Year = 1801;
        }

        public Book(string title, string author, int year)
        {
            Title = title;
            Author = author;
            Year = year;
        }

        public override string GetDocumentType()
        {
            return "Book";
        }

        public string PrintInfo()
        {
            return ToString();
        }

        public override string ToString()
        {
            return $"Название: {Title}, автор: {Author}, год: {Year}";
        }
    }

    public class Library
    {
        private readonly List<Book> listBook = new List<Book>();

        public int Count => listBook.Count;

        public void AddBook()
        {
            Console.WriteLine("Введите сведения о книге, которую хотите добавить.");

            Console.Write("Автор: ");
            string addAuthor = (Console.ReadLine() ?? "").Trim();

            Console.Write("Название: ");
            string addTitle = (Console.ReadLine() ?? "").Trim();

            int addYear;
            while (true)
            {
                Console.Write("Год (число > 1800): ");
                var raw = Console.ReadLine();
                if (int.TryParse(raw, out addYear) && addYear > 1800) break;
                Console.WriteLine("Некорректный год. Повторите ввод.");
            }

            bool exists = false;
            foreach (var b in listBook)
            {
                if (string.Equals(b.Title, addTitle, StringComparison.OrdinalIgnoreCase))
                {
                    exists = true;
                    break;
                }
            }
            if (exists)
            {
                Console.WriteLine("Книга с таким названием уже имеется в библиотеке.");
                return;
            }

            var newBook = new Book(addTitle, addAuthor, addYear);

            Console.Write("Подтвердите добавление (y/n): ");
            var key = Console.ReadKey(intercept: true).KeyChar;
            Console.WriteLine();
            if (char.ToLowerInvariant(key) == 'y' || char.ToLowerInvariant(key) == 'н')
            {
                listBook.Add(newBook);
                Book.TotalBooks++;
                Console.WriteLine($"Добавлена книга: \"{newBook.Title}\" ({newBook.Author}, {newBook.Year})");
            }
            else
            {
                Console.WriteLine("Действие отменено.");
            }
        }

        public void RemoveBook(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                Console.WriteLine("Название не задано.");
                return;
            }

            Book book = null;
            var searchTitle = title.Trim();
            foreach (var b in listBook)
            {
                if (string.Equals(b.Title, searchTitle, StringComparison.OrdinalIgnoreCase))
                {
                    book = b;
                    break;
                }
            }

            if (book == null)
            {
                Console.WriteLine("Книга не найдена.");
                return;
            }

            Console.Write($"Удалить книгу \"{book.Title}\"? (y/n): ");
            var key = Console.ReadKey(intercept: true).KeyChar;
            Console.WriteLine();
            if (char.ToLowerInvariant(key) == 'y' || char.ToLowerInvariant(key) == 'н')
            {
                listBook.Remove(book);
                if (Book.TotalBooks > 0) Book.TotalBooks--;
                Console.WriteLine("Книга удалена.");
            }
            else
            {
                Console.WriteLine("Действие отменено.");
            }
        }

        public void FindBooksByAuthor(string author)
        {
            if (string.IsNullOrWhiteSpace(author))
            {
                Console.WriteLine("Автор не задан.");
                return;
            }

            author = author.Trim();
            int foundCount = 0;

            foreach (var b in listBook)
            {
                if (string.Equals(b.Author, author, StringComparison.OrdinalIgnoreCase))
                {
                    if (foundCount == 0)
                        Console.WriteLine($"Найдены книги автора \"{author}\":");
                    Console.WriteLine($"- \"{b.Title}\" ({b.Year})");
                    foundCount++;
                }
            }

            if (foundCount == 0)
            {
                Console.WriteLine($"Книги автора \"{author}\" не найдены.");
            }
        }

        public void DisplayAllBooks()
        {
            if (listBook.Count == 0)
            {
                Console.WriteLine("В библиотеке нет книг.");
                return;
            }

            Console.WriteLine("Список всех книг:");
            foreach (var b in listBook)
            {
                Console.WriteLine(b.PrintInfo());
            }
        }
    }

    class Program
    {
        public static void Main()
        {
            var library = new Library();

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Выберите действие:");
                Console.WriteLine("1 - Добавить книгу");
                Console.WriteLine("2 - Кол-во книг в библиотеке");
                Console.WriteLine("3 - Найти книгу по автору");
                Console.WriteLine("4 - Удалить книгу по названию");
                Console.WriteLine("5 - Просмотр всех книг");
                Console.WriteLine("0 - Выход");
                Console.Write("Ваш выбор: ");

                var choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        library.AddBook();
                        break;
                    case "2":
                        Console.WriteLine($"Всего книг в библиотеке: {library.Count} (TotalBooks: {Book.TotalBooks})");
                        break;
                    case "3":
                        Console.Write("Введите автора для поиска: ");
                        library.FindBooksByAuthor(Console.ReadLine());
                        break;
                    case "4":
                        Console.Write("Введите название книги, которую хотите удалить: ");
                        library.RemoveBook(Console.ReadLine());
                        break;
                    case "5":
                        library.DisplayAllBooks();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Нет действия с данным номером.");
                        break;
                }
            }
        }
    }
}
