using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOP
{
    class Book:Document,IPrintable
    {
        private string _title 
        {
            get
            {
                return _title;
            }
            set
            {
                _title = value;
            }
        }
        private string _author 
        {
            get
            {
                return _author;
            }
            set
            {
                _author = value;
            }
        }
        private int _year 
        {
            get
            {
                return _year;
            }
            set
            {
                if(value > 1800)
                {
                    _year = value;
                }
                else
                {
                    Console.WriteLine("Значение должно быть больше 1800");
                }
            }
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
    abstract class Document 
    {
        int id { get; set; }
        string title { get; set; }
        public abstract string GetDocumentType();

    }
    interface IPrintable
    {
        string PrintInfo();
    }
    class Lybrary
    {
        private List<Book> list_book;
        static void AddBook(Book book)
        {

        }
        static void RemoveBook(string title) 
        {
            Console.Write("Введите название книги которую хотите удалить: ");
            string name_book = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Подтвердите что хотите удалить данную книгу (y/n)");
            string confirm = Convert.ToString(Console.ReadKey());
            if (confirm.ToLower() == "y" && name_book.ToLower() == )
            {

            }
        }
        static void FindBooksByAuthor(string author)
        {

        }
        static void DisplayAllBook()
        {

        }
    }
}
