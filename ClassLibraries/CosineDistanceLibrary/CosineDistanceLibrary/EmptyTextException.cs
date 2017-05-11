using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosineSimilarityLibrary
{
    public class EmptyTextException : Exception
    {
        public EmptyTextException() : base()
        { }

        public EmptyTextException(string message) : base(message)
        { }
    }
}
