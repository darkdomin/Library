using Library.libraryModel.ExceptionMy;
using Library.libraryModel.models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Library.libraryModel.io.FileMy
{
    public class SerializableFileManager : FileManager
    {
        private const string FILE_NAME = "Library.o";
        public void ExportData(LibraryCl library)
        {
            Dictionary<string,Publication> publications = library.Publications;
            try
            {
                IFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream(FILE_NAME, FileMode.Append, FileAccess.Write);

                formatter.Serialize(stream, publications);

                stream.Close();

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
            Publication[] zwrot = null;
            LibraryCl library = new LibraryCl();

            Stream stream;
            if (File.Exists(FILE_NAME))
            {
                stream = new FileStream(FILE_NAME, FileMode.Open);
                IFormatter formatter = new BinaryFormatter();

                while (true)
                {
                    try
                    {
                        zwrot = (Publication[])formatter.Deserialize(stream);
                    }
                    catch (Exception)
                    {
                        break;
                    }
                }
            }
            else
            {
                throw new DataImportException("Błąd odczytu danych " + FILE_NAME);
            }

            stream.Close();

            foreach (var publikacja in zwrot)
            {
                library.AddPublication(publikacja);
            }

            return library;
        }
    }
}
