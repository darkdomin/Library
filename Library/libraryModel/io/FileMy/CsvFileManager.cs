using Library.libraryModel.ExceptionMy;
using Library.libraryModel.models;
using System;
using System.IO;
using System.Linq;

namespace Library.libraryModel.io.FileMy
{
    public class CsvFileManager : FileManager
    {
        private const string FILE_NAME = "Library.csv";
        private const string FILE_USERS = "USERS.csv";
        public void ExportData(LibraryCl library)
        {
            ExportPublications(library);
            ExportUsers(library);
        }

        private void ExportUsers(LibraryCl library)
        {
            var users = library.Users.Values;

            try
            {
                using (StreamWriter file = new StreamWriter(FILE_USERS, true))
                {
                    foreach (var user in users)
                    {
                        file.WriteLine(user.ToCSV());
                    }
                }

            }
            catch (IOException e)
            {
                throw new DataExportException("Błąd zapisu danych " + FILE_NAME + " " + e.Message);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        private void ExportPublications(LibraryCl library)
        {
            var publications = library.Publications.Values;

            try
            {
                using (StreamWriter file = new StreamWriter(FILE_NAME, true))
                {
                    foreach (var publication in publications)
                    {
                        file.WriteLine(publication.ToCSV());
                    }
                }

            }
            catch (IOException e)
            {
                throw new DataExportException("Błąd zapisu danych " + FILE_NAME + " " + e.Message);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public LibraryCl ImportData()
        {
            LibraryCl library = new LibraryCl();
             ImportPublications(library);
             ImportUsers(library);
            return library;
        }

        private void ImportUsers(LibraryCl library)
        {
            if (File.Exists(FILE_NAME))
            {
                var query = File.ReadAllLines(FILE_USERS)

                                .Select(l =>
                                {
                                    return  ModelUsera(l);
                                });

                foreach (var item in query)
                {
                    library.AddUser(item);
                }
            }
            else
            {
                throw new DataImportException("Brak Pliku!");
            }
        }

        private LibraryUser ModelUsera(string l)
        {
            var columns = l.Split(';');

            string Name = columns[0];
            string LastName = columns[1];
            string ID = columns[2];
          
            return new LibraryUser(Name, LastName, ID);
        }

        private void ImportPublications(LibraryCl library)
        {
            if (File.Exists(FILE_NAME))
            {
                var query = File.ReadAllLines(FILE_NAME)

                                .Select(l =>
                                {
                                    return  ModelPublikacji(l);
                                });

                foreach (var item in query)
                {
                    library.AddPublication(item);
                }
            }
            else
            {
                throw new DataImportException("Brak Pliku!");
            }
        }

        private Publication ModelPublikacji(string l)
        {
            var columns = l.Split(';');

            if (columns[0].Equals( Book.TYPE))
            {
                string title = columns[1];
                string author = columns[2];
                int releaseDate = int.Parse(columns[3]);
                int pages = int.Parse(columns[4]);
                string publisher = columns[5];
                string isbn = columns[6];
                return new Book(title, author, releaseDate, pages, publisher, isbn);
            }
            else
            if (columns[0].Equals(Magazine.TYPE))
            {
                string title = columns[1];
                string publisher = columns[2];
                int releaseDate = int.Parse(columns[3]);
                string language = columns[4];
                return new Magazine(title, publisher, releaseDate, language);

            }
            else throw new Exception("Błąd danych");
        }
    }
}
