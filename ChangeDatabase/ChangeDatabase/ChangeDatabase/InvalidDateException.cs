using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangeDatabase
{
    class InvalidDateException : Exception
    {
        public InvalidDateException() { }

        public InvalidDateException(string message) : base(message) { }

        public InvalidDateException(string message, Exception innerException) : base(message, innerException) { }
    }
}
