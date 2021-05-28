using Library.libraryModel.models;
using System.Collections.Generic;
using System.Linq;

namespace Library.libraryModel.io
{
    public class ConsolePrinter
    {
        private const string MAGAZINE_TYPE = "Magazine";
        private const string BOOK_TYPE = "Book";
        public void PrintMagazines(ICollection<Publication> publications)
        {
            int countMagazines = 0;

            IEnumerable<string> zwrot = Filter(publications, MAGAZINE_TYPE);
            countMagazines = PrintFilter(countMagazines, zwrot);
        }

        public void PrintBooks(ICollection<Publication> publications)
        {
            int countBooks = 0;

            IEnumerable<string> zwrot = Filter(publications, BOOK_TYPE);
            countBooks = PrintFilter(countBooks, zwrot);
        }

        private static IEnumerable<string> Filter(ICollection<Publication> publications, string type)
        {
            return publications.Where(p => p.GetType().Name == type)
                                    .Select(p => p.ToString());
        }

        private static int PrintFilter(int countType, IEnumerable<string> zwrot)
        {
            foreach (var publication in zwrot)
            {
                PrintLine(publication);
                countType++;
            }
            if (countType == 0)
            {
                PrintLine("Brak magazynów w bibliotece.");
            }

            return countType;
        }

        public static void PrintLine(string text)
        {
            System.Console.WriteLine(text);
        }

        public void PrintUsers(ICollection<LibraryUser> users)
        {
            foreach (var user in users)
            {
                ConsolePrinter.PrintLine(user.ToString());
            }
        }
    }
}
