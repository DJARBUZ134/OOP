using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOP
{
    public class Book : Document,IPrintable
    {
        private string title = "Under";
        private string author = "Under";
        private int year = 1801;

        public string _title 
        {
            get
            {
                return title;
            }
            set
            {
               title = value;
            }
        }
        public string _author 
        {
            get
            {
                return author;
            }
            set
            {
                author = value;
            }
        }
        public int _year 
        {
            get
            {
                return year;
            }
            set
            {
                    year = value;
            }
        }
        public Book()
        {
            _title = "ndan";
            _author ="fas ";
            _year =1801;
        }
        public Book(string title, string author, int year)
        {
            _title = title;
            _author = author;
            _year = year;
        }

        public static int TotalBooks;

        public override string GetDocumentType()
        {
            throw new NotImplementedException();// тут короче код
        }

        public string PrintInfo()
        {
            throw new NotImplementedException();// тут короче код
        }
        public override string ToString()
        {
            string txt = ($"Название: {_title}, автор: {_author}, год: {_year}");
            return txt;
        }       
    }

    public class Library : Book
    {        
        private List<Book> list_book = new List<Book>();

        public void AddBook(Book book)
        {
            Program obj = new Program();
            Console.Write("Введите свединие о книги которую хотите добавить: ");

            Console.WriteLine("Введите автора");
            string add_author = Convert.ToString(Console.ReadLine());

            Console.WriteLine("Введите название");
            string add_title = Convert.ToString(Console.ReadLine());


            // Проверка конвертирования, Не добавлять буквы, Не меньше 1800
            Console.WriteLine("Введите год");
            int add_year = Convert.ToInt32(Console.ReadLine());

            Book add_name_book = new Book(add_author, add_title, add_year);

            Console.WriteLine("Подтвердите что хотите добавить данную книгу (y/n)");
            string add_confirm = Convert.ToString(Console.ReadKey());

            if (add_confirm.ToLower() == "y")
            {
                if (list_book.Contains(add_name_book) == false)

                    list_book.Add(add_name_book);
            }
            else
            {
                Console.WriteLine("Книга с таким названием уже имеется в библиотеке");
            }

            obj.Meth();
        }
    
        static void RemoveBook(string title) 
        {
            Console.Write("Введите название книги которую хотите удалить: ");
            string delete_name_book = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Подтвердите что хотите удалить данную книгу (y/n)");
            string delete_confirm = Convert.ToString(Console.ReadKey());
            //if (delete_confirm.ToLower() == "y" && delete_name_book.ToLower() == )
            //{

            //}
        }
        static void FindBooksByAuthor(string author)
        {
            Console.WriteLine("Введите автора для поиска: ");
            string find_name_book = Convert.ToString(Console.ReadLine());
            //list_book.FindAll((find_name_book));
        }
        static void DisplayAllBook()
        {

        }
    }

    public abstract class Document
    {
        int id;
        string title;
        public abstract string GetDocumentType();

    }

    interface IPrintable
    {
        string PrintInfo();
    }

    class Program
    {

        public void Meth()
        {
            Console.Clear();
            Main();
        }

        public static void Main()
        {
            Library obj = new Library();
            Book book1 = new Book();

            Console.WriteLine("Выберите действие: ");
            Console.WriteLine("1 - Добавить книгу ");
            Console.WriteLine("2 - Кол-во книг в библиотеке ");
            Console.WriteLine("3 - Найти книгу по автору ");
            Console.WriteLine("4 - Удалить книгу по названию");
            Console.WriteLine("5 - Просмотр всех книг ");

            string devst = Console.ReadLine();
            
            switch (devst)
            {
                case "1":
                    { 
                        obj.AddBook(book1);
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Нет действия с данным номером");
                        break;
                    }
            }
        }

    }
}
