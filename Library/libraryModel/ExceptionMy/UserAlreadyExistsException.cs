using System;

namespace Library.libraryModel.ExceptionMy
{
    class UserAlreadyExistsException : Exception
    {
        public UserAlreadyExistsException(string message) : base(message)
        {

        }

    }
}
