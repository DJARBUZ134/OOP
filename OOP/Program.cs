using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOP
{
    class Book:Document,IPrintable
    {
        private string _title {get; set;}
        private string _author { get; set; }
        private int _year { get; set; }

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
            return base.ToString();
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
