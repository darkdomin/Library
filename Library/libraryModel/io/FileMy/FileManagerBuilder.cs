using Library.libraryModel.ExceptionMy;
using System;

namespace Library.libraryModel.io.FileMy
{
    public class FileManagerBuilder
    {
        private ConsolePrinter printer;
        private DataReader reader;

        public FileManagerBuilder(ConsolePrinter printer, DataReader reader)
        {
            this.printer = printer;
            this.reader = reader;
        }

        public FileManager Build()
        {
            ConsolePrinter.PrintLine("Wybierz format danych: ");
            FileType fileType = GetFileType();
            switch (fileType)
            {
                case FileType.SERIAL:
                    return new SerializableFileManager();
                case FileType.CSV:
                    return new CsvFileManager();
                default:
                    throw new NoFileSuchException("Nieobsługiwany typ danych.");
            }
        }

        private FileType GetFileType()
        {
            bool typeOk = false;
            FileType result = 0;

            do
            {
                PrinTypes();
                string type = reader.GetString().ToUpper();
                try
                {
                    var arr = Enum.GetValues(typeof(FileType));
                    foreach (var item in arr)
                    {
                        if (item.ToString() == type)
                        {
                            result = (FileType)item;
                            typeOk = true;
                        }
                    }

                }
                catch (Exception e)
                {
                    ConsolePrinter.PrintLine("Nieobsługiwany typ danych");
                }

            } while (!typeOk);

            return result;
        }

        private FileType PodajTyp()
        {
            string type = reader.GetString().ToUpper();
            try
            {
                var arr = Enum.GetValues(typeof(FileType));
                foreach (var item in arr)
                {
                    if (item == arr) return (FileType)item;
                }
            }
            catch (Exception e)
            {
                ConsolePrinter.PrintLine("Nieobsługiwany typ danych");
            }

            return FileType.SERIAL;
        }

        private void PrinTypes()
        {
            foreach (var value in Enum.GetValues(typeof(FileType)))
            {
                ConsolePrinter.PrintLine(value.ToString());
            }
        }
    }
}
