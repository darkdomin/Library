using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.libraryModel.ExceptionMy
{
    public class NoFileSuchException : Exception
    {
        public NoFileSuchException(string message) : base(message)
        {

        }
    }
}
