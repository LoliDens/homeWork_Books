using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homeWork_Books
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Library labrary = new Library(new List<Book>
            {
            new Book("Перступление и наказание", "Достоевский",1866),
            new Book("Война и мир", "Толстой",1820),
            new Book("Мартышка и очки","Крылов",1815)
            });

            labrary.Work();     
        }
    }

    class Book 
    {
        public string Name { get; private set; }
        public string Author { get; private set; }
        public int YearRelease { get; private set; }

        public Book(string name, string author, int yearRelease)
        {
            Name = name;
            Author = author;
            YearRelease = yearRelease;
        }

        public void ShowInfo() 
        {
            Console.WriteLine($"Автор: {Author}" +
                   $"\nНазвание: {Name}" +
                   $"\nГод издания: {YearRelease}\n\n");
        }
    }

    class Library 
    {
        private List<Book> _books = new List<Book>();

        public Library(List<Book> books) 
        {
            _books = books;
        }

        public void Work() 
        {
            const string CommandAddBook = "1";
            const string CommandDeleteBook = "2";
            const string CommandShowBooks = "3";
            const string CommandFaidBook = "4";
            const string CommandExit = "0";

            Console.WriteLine("Добро пожаловать в библиотеку!");
            bool isExit = false;

            while (isExit == false)
            {
                Console.WriteLine("Нажмите:" +
                    $"\n{CommandAddBook} - Добавить книгу" +
                    $"\n{CommandDeleteBook} - Удалить книгу" +
                    $"\n{CommandShowBooks} - Показать все книги" +
                    $"\n{CommandFaidBook} - Поис книги по параметрам" +
                    $"\n{CommandExit} - Выйти из программы");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case CommandAddBook:
                        AddBook();
                        break;

                    case CommandDeleteBook:
                        DeleteBook();
                        break;

                    case CommandShowBooks:
                        ShowAllBooks();
                        break;

                    case CommandFaidBook:
                        SearchBooks();
                        break;

                    case CommandExit:
                        isExit = true;
                        break;

                    default:
                        Console.WriteLine("Комманда не распознана");
                        break;
                }

                Console.ReadLine();
                Console.Clear();
            }
        }
              
        private void AddBook() 
        {
            Console.Write("Введите данный о кние:" +
                "\nНазвание - ");
            string name = Console.ReadLine();
            Console.Write("Автор - ");
            string author = Console.ReadLine();
            Console.Write("Год выпуска - ");
            int yearRelease = ReadNumber();

            _books.Add(new Book(name, author, yearRelease));
        }

        private void DeleteBook() 
        {
            Console.Write("Введите номер книги которую хотите удалить - ");
            int indexBook = ReadNumber();

            if (indexBook < 1 || indexBook > _books.Count)
            {
                Console.WriteLine("Книга с данным номером не найдена");
            }
            else 
            {
                _books.RemoveAt(indexBook - 1);
            }           
        }

        private void ShowAllBooks() 
        {
            for (int i = 0; i < _books.Count; i++)
            {
                Book book = _books[i];

                Console.WriteLine($"{i+1}.");
                book.ShowInfo();
            }
        }

        private void SearchBooks()
        {
            const string CommandShowByNames = "1";
            const string CommandShowByAuthors = "2";
            const string CommandShowByYear = "3";


            Console.WriteLine($"По какому параметру вы хотите найти книгу" +
                $"\n{CommandShowByNames} - название" +
                $"\n{CommandShowByAuthors} - автор" +
                $"\n{CommandShowByYear} - год выпуска ");

            string userInput = Console.ReadLine();

            switch (userInput) 
            {
                case CommandShowByNames:
                    ShowByNames();
                    break;

                case CommandShowByAuthors:
                    ShowByAuthors();
                    break;

                case CommandShowByYear:
                    ShowByYear();
                    break;

                default:
                    Console.WriteLine("Комманда не распознана");
                    break;
            }
        }

        private void ShowByNames() 
        {
            Console.Write("Введите название книги которую хотите найти: ");
            string nameBook = Console.ReadLine();
            bool haveBook = false;

            foreach (var book in _books) 
            {
                if (book.Name == nameBook) 
                {
                    Console.WriteLine($"Автор: {book.Author}" +
                    $"\nНазвание: {book.Name}" +
                    $"\nГод издания: {book.YearRelease}");
                    haveBook = true;
                }
            }

            if (haveBook == false) 
                Console.WriteLine("Книга с таким название не найдена");
                       
        }

        private void ShowByAuthors() 
        {
            Console.Write("Введите автора книги которую хотите найти: ");
            string auther = Console.ReadLine();
            bool haveBook = false;

            foreach (var book in _books)
            {
                if (book.Author == auther)
                {
                    Console.WriteLine($"Автор: {book.Author}" +
                    $"\nНазвание: {book.Name}" +
                    $"\nГод издания: {book.YearRelease}");
                    haveBook = true;
                }
            }

            if (haveBook == false)
                Console.WriteLine("Книга с таким автором не найдена");

        }

        private void ShowByYear() 
        {
            Console.Write("Введите год выпуска книги которую хотите найти: ");
            int year = ReadNumber();
            bool haveBook = false;

            foreach (var book in _books)
            {
                if (book.YearRelease == year)
                {
                    Console.WriteLine($"Автор: {book.Author}" +
                    $"\nНазвание: {book.Name}" +
                    $"\nГод издания: {book.YearRelease}");
                    haveBook = true;
                }
            }

            if (haveBook == false)
                Console.WriteLine("Книга с данным годом выпуска не найдина");
        }

        private int ReadNumber()
        {
            int result;
            string numberForConvert = Console.ReadLine();


            while (int.TryParse(numberForConvert, out result) == false)
            {
                Console.WriteLine("Ошибка. Ведите число повтороно - ");
                numberForConvert = Console.ReadLine();
            }

            return result;
        }
    }    
}
