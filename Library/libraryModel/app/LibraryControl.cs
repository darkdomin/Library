using Library.libraryModel.ExceptionMy;
using Library.libraryModel.io;
using Library.libraryModel.io.FileMy;
using Library.libraryModel.models;
using Library.libraryModel.models.Comparator;
using System;
using System.Collections.Generic;

namespace Library.libraryModel.app
{
    class LibraryControl
    {
        static readonly ConsolePrinter printer = new ConsolePrinter();
        readonly DataReader dataReader = new DataReader(printer);
        readonly LibraryCl library = new LibraryCl();
        SerializableFileManager serial = new SerializableFileManager();
        FileManager fileManager;
        readonly CsvFileManager csvFile = new CsvFileManager();

        public LibraryControl()
        {
            fileManager = new FileManagerBuilder(printer, dataReader).Build();
            try
            {
                library = fileManager.ImportData();
                ConsolePrinter.PrintLine("Zaimportowano dane");
            }
            catch (DataImportException e)
            {
                ConsolePrinter.PrintLine(e.Message);
                ConsolePrinter.PrintLine("danych nie zaimportowano!");
            }
            catch(PublicationAlreadyExistsException ex)
            {
                ConsolePrinter.PrintLine(ex.Message);
                ConsolePrinter.PrintLine("danych nie zaimportowano!");
            }
        }

        public void ControlLoop()
        {
            Option option;

            do
            {
                PrintOptions();

                option = GetOption();
                switch (option)
                {
                    case Option.EXIT:
                        try
                        {
                            fileManager.ExportData(library);
                            csvFile.ExportData(library);

                        }
                        catch (DataExportException e)
                        {
                            ConsolePrinter.PrintLine(e.Message);
                        }
                        ConsolePrinter.PrintLine("Dane zostały wyeksportowane do pliku.");
                        Exit();
                        break;
                    case Option.ADD_BOOK:
                        AddBook();
                        break;
                    case Option.PRINT_BOOK:
                        PrintBooks();
                        break;
                    case Option.ADD_MAGAZINES:
                        AddMagazine();
                        break;
                    case Option.DELETE_BOOK:
                        DeleteBook();
                        break;
                    case Option.DELETE_MAGAZINE:
                        DeleteMagazine();
                        break;
                    case Option.PRINT_MAGAZINES:
                        PrintMagazines();
                        break;
                    case Option.LOAD:
                        PrintPublication();
                        break;
                    case Option.ADD_USER:
                        AddUser();
                        break;
                    case Option.DELETE_USER:
                       // DeleteUser();
                        break;
                    case Option.PRINT_USERS:
                        PrintUsers();
                        break;
                    default:
                        ConsolePrinter.PrintLine("Nie ma takiej opcji.");
                        break;
                }

            } while (option != Option.EXIT);
        }

        private void PrintUsers()
        {
            var p = library.Users;
            printer.PrintUsers(library.GetSortedUsers(new AlphabeticalComparatorUser()));
        }

        private void DeleteUser(ICollection<LibraryUser> user)
        {
          //  if(library.Publications.)
        }

        private void AddUser()
        {
            LibraryUser user = dataReader.ReadAndCreateUser();
            try
            {
                library.AddUser(user);

            }catch(UserAlreadyExistsException e)
            {
                ConsolePrinter.PrintLine(e.Message);
            }
        }

        private void DeleteMagazine()
        {
            try
            {
                Magazine magazine = dataReader.ReadAndCreateMagazine();
                if (library.RemovePublication(magazine))
                {
                    ConsolePrinter.PrintLine("Usunięto magazyn");
                }
                else
                {
                    ConsolePrinter.PrintLine("Nie ma takiego magazynu");
                }
            }catch(Exception e)
            {
                ConsolePrinter.PrintLine(e.Message);
            }
        }

        private void DeleteBook()
        {
            try
            {
                Book book = dataReader.ReadAndCreateBook();
                if (library.RemovePublication(book))
                {
                    ConsolePrinter.PrintLine("Usunięto książkę");
                }
                else
                {
                    ConsolePrinter.PrintLine("Nie ma takiej książki");
                }
            }
            catch (Exception e)
            {
                ConsolePrinter.PrintLine(e.Message);
            }
        }

        private void PrintPublication()
        {
            var publications = library.GetSortedPublications(new AlphabeticalComparator());//
            int countBooks = 0;
            foreach (var publication in publications)
            {
                if (publication != null)
                {
                    ConsolePrinter.PrintLine(publication.ToString());
                    countBooks++;
                }
            }
        }


        private Option GetOption()
        {
            while (true)
            {
                try
                {
                    return CreateFromInt(dataReader.GetInt());
                }
                catch (NoSuchOptionException e)
                {
                    ConsolePrinter.PrintLine(e.Message);
                }
                catch (FormatException e)
                {
                    ConsolePrinter.PrintLine("Nacisnięto literę");
                }
            };
        }

        private Option CreateFromInt(int option)
        {
            try
            {
                var enums = Enum.GetValues(typeof(Option));
                return (Option)enums.GetValue(option);
            }
            catch (IndexOutOfRangeException ex)
            {
                throw new NoSuchOptionException("Brak opcji o id " + option + " " +ex.Message);
            }
        }

        public void PrintMagazines()
        {
            printer.PrintMagazines(library.GetSortedPublications(new DateComparator()));
        }

        private void AddMagazine()
        {
            try
            {
                Magazine magazine = dataReader.ReadAndCreateMagazine();
                library.AddPublication(magazine);
            }
            catch (FormatException e)
            {
                ConsolePrinter.PrintLine("Nieprawidłowy znak");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                ConsolePrinter.PrintLine("Osiągnięto limit biblioteki");
            }
        }

        private void Exit()
        {
            ConsolePrinter.PrintLine("Koniec programu, do widzenia.");
            return;
        }

        private void PrintBooks()
        {
            printer.PrintBooks(library.GetSortedPublications(new AlphabeticalComparator()));
        }

        private void AddBook()
        {
            try
            {
                Book book = dataReader.ReadAndCreateBook();
                library.AddPublication(book);
            }
            catch (FormatException e)
            {
                ConsolePrinter.PrintLine("Nieprawidłowy znak");

            }
            catch (ArgumentOutOfRangeException ex)
            {
                ConsolePrinter.PrintLine("Osiągnięto limit biblioteki");
            }
        }

        public static void PrintOptions()
        {
            ConsolePrinter.PrintLine(CreateFromOption(Option.EXIT) + " - Wyjście z programu");
            ConsolePrinter.PrintLine(CreateFromOption(Option.ADD_BOOK) + " - Dodanie nowej książki");
            ConsolePrinter.PrintLine(CreateFromOption(Option.ADD_MAGAZINES) + " - Dodanie nowego magazynu");
            ConsolePrinter.PrintLine(CreateFromOption(Option.PRINT_BOOK) + " - Wyświetl dostępne książki");
            ConsolePrinter.PrintLine(CreateFromOption(Option.PRINT_MAGAZINES) + " - Wyświetl dostępne magazyny");
            ConsolePrinter.PrintLine(CreateFromOption(Option.DELETE_BOOK) + " - Usuń książkę");
            ConsolePrinter.PrintLine(CreateFromOption(Option.DELETE_MAGAZINE) + " - Usuń magazyn");
            ConsolePrinter.PrintLine(CreateFromOption(Option.LOAD) + " - Wyświetl wszystkie zapisane publikacje");
            ConsolePrinter.PrintLine(CreateFromOption(Option.ADD_USER) + " - Dodaj Użytkownika");
            ConsolePrinter.PrintLine(CreateFromOption(Option.DELETE_USER) + " - Usuń użytkownika");
            ConsolePrinter.PrintLine(CreateFromOption(Option.PRINT_USERS) + " - Wypisz użytkownika");
        }

        private static int CreateFromOption(Option option)
        {
            return (int)option;
        }
    }
}
