using Library.libraryModel.io;
using System;

namespace Library.libraryModel.app
{
    public class PrinterOption
    {
        public static void PrintOptions(Option option, string description)
        {
            ConsolePrinter.PrintLine(option + description);
        }
    }
}
