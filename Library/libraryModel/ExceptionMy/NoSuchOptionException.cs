using System;

namespace Library.libraryModel.ExceptionMy
{
    public class NoSuchOptionException : Exception
    {
        public NoSuchOptionException(string message) : base(message)
        {

        }
    }
}
