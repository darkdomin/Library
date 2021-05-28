using Library.libraryModel.models;
using System;

namespace Library.libraryModel.io
{
    public class DataReader
    {
        private readonly ConsolePrinter consolePrinter;

        public DataReader(ConsolePrinter consolePrinter)
        {
            this.consolePrinter = consolePrinter;
        }
        public Book ReadAndCreateBook()
        {
            ConsolePrinter.PrintLine("Podaj Tytuł:");
            string title = Console.ReadLine();
            ConsolePrinter.PrintLine("Podaj autora:");
            string author = Console.ReadLine();
            ConsolePrinter.PrintLine("Podaj rok wydania:");
            int year = int.Parse(Console.ReadLine());
            ConsolePrinter.PrintLine("Podaj ilość stron:");
            int pages = int.Parse(Console.ReadLine());
            ConsolePrinter.PrintLine("Podaj wydawcę:");
            string publisher = Console.ReadLine();
            
            ConsolePrinter.PrintLine("Podaj nr isbn:");
            string isbn = Console.ReadLine();

            return new Book(title, author, year, pages, publisher, isbn);
        }

        public Magazine ReadAndCreateMagazine()
        {
            ConsolePrinter.PrintLine("Podaj Tytuł:");
            string title = Console.ReadLine();
            ConsolePrinter.PrintLine("Podaj wydawcę:");
            string publisher = Console.ReadLine();
            ConsolePrinter.PrintLine("Podaj rok wydania:");
            int year = int.Parse(Console.ReadLine());
            ConsolePrinter.PrintLine("Podaj język wydania:");
            string language = Console.ReadLine();

            return new Magazine(title, publisher, year, language);
        }

        public LibraryUser ReadAndCreateUser()
        {
            ConsolePrinter.PrintLine("Podaj Imię użytkownika:");
            string name = Console.ReadLine();
            ConsolePrinter.PrintLine("nazwisko:");
            string lastName = Console.ReadLine();
            ConsolePrinter.PrintLine("Podaj pesel:");
            string pesel = Console.ReadLine();

            return new LibraryUser(name, lastName, pesel);
        }

        public int GetInt()
        {
            return int.Parse(Console.ReadLine());
        }
        public string GetString()
        {
            return Console.ReadLine();
        }
    }
}
