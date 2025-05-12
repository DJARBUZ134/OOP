using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOP
{
    class Book : Document,IPrintable
    {
        private string _title { get; set;}
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
    class Library
    {
        static List<string> list_book = new List<string>();
        static void AddBook(string book)
        {
            Console.Write("Введите название книги которую хотите добавить: ");
            string add_name_book = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Подтвердите что хотите добавить данную книгу (y/n)");
            string add_confirm = Convert.ToString(Console.ReadKey());
            if (add_confirm.ToLower() == "y")
            {
                if (list_book.Contains(Convert.ToString(add_name_book)) == false)
                    list_book.Add(add_name_book);
                else
                    Console.WriteLine("Книга с таким названием уже имеется в библиотеке");
            }
        }
        static void RemoveBook(string title) 
        {
            Console.Write("Введите название книги которую хотите удалить: ");
            string delete_name_book = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Подтвердите что хотите удалить данную книгу (y/n)");
            string delete_confirm = Convert.ToString(Console.ReadKey());
            if (delete_confirm.ToLower() == "y" && delete_name_book.ToLower() == )
            {

            }
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
}
