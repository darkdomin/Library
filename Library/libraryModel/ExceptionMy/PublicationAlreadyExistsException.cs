using System;

namespace Library.libraryModel.ExceptionMy
{
    class PublicationAlreadyExistsException : Exception
    {
        public PublicationAlreadyExistsException(string message) : base(message)
        {
                
        }
    }
}
