using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab_13
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BookRealization<int> harryPotter = new BookRealization<int>();
            harryPotter.PublishingDate(25062000);
            BookRealization<string> neznayka= new BookRealization<string>();
            neznayka.PublishingDate("12/05/1960");

            UserLog_in<string> mihail = new UserLog_in<string>("Mihail225");
            mihail.Autontification("12336-Ab");
            UserLog_in<int> vasiliy = new UserLog_in<int>(123456);
            vasiliy.Autontification("12336-Ba");

            Shopping<string, string> chitayGorod = new Shopping<string, string>(mihail.login);
            chitayGorod.BookAction("HarryPotter");
            chitayGorod.AutorAction("Joan Rouling");
            chitayGorod.Buy();
        }
        
    }
    interface IPublishingHouse
    {
        void BookAction(string name);
        void AutorAction(string name);
    }
    interface IBook<T> : IPublishingHouse
    {
        void PublishingDate(T date);
        void PageQuantity(int pages);
    }
    interface IUser<N>
    {
        void Autontification(string pass);
    }
    class BookRealization<T> : IBook<T>
    {
        public void AutorAction(string name)
        {
            Console.WriteLine($"{name} автор этой книги");
        }

        public void BookAction(string bookName)
        {
            Console.WriteLine($"Книга {bookName} открыта");
        }

        public void PageQuantity(int pages)
        {
            Console.WriteLine($"Количество страниц в книге равно {pages}");
        }

        public void PublishingDate(T date)
        {
            Console.WriteLine($"Дата публикации книги: {date}");
        }
    }
    class UserLog_in<N> : IUser<N>
    {
        public N login;
        string password = "12336-Ab";
        public  UserLog_in(N login)
        {
            this.login = login;
        }
        public void Autontification(string pass)
        {
            if(pass == password)
            {
                Console.WriteLine($"Пользователь {login} успешно вошёл в систему");
            }
            else
            {
                Console.WriteLine("Введён неправильный пароль");
            }
        }
    }
    class Shopping<T, N> : IUser<N>, IBook<T>
    {
        public N login;
        string password = "12336-Ab";
        private string book;
        private string autor;
        public Shopping(N login)
        {
            this.login = login;
        }
        public void Autontification(string pass)
        {
            if (pass == password)
            {
                Console.WriteLine($"Пользователь {login} успешно вошёл в систему");
            }
            else
            {
                Console.WriteLine("Введён неправильный пароль");
            }
        }

        public void AutorAction(string name)
        {
            autor = name;
        }

        public void BookAction(string bookName)
        {
            book = bookName;
        }

        public void PageQuantity(int pages)
        {
            Console.WriteLine($"Эта книга содержит {pages} листов");
        }

        public void PublishingDate(T date)
        {
            Console.WriteLine($"Дата публикации этой книги: {date}");
        }
        public void Buy()
        {
            Console.WriteLine($"{login} купил книгу {book} за авторством {autor}");
        }
    }
}
