using Library.libraryModel.app;
using System;

namespace Library
{
    class Program
    {
        private const string APP_NAME = "Biblioteka v1.8";
        static void Main(string[] args)
        {
            Console.WriteLine(APP_NAME);

            LibraryControl librarycontrol = new LibraryControl();
            librarycontrol.ControlLoop();
         
            Console.ReadKey();
        }
    }
}
