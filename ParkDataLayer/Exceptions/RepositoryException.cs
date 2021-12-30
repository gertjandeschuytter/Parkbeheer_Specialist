using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkDataLayer.Exceptions
{
    public class RepositoryException : Exception
    {
        public RepositoryException(string message) : base(message)
        {
        }

        public RepositoryException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
