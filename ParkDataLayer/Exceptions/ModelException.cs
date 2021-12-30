using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkDataLayer.Exceptions
{
    public class ModelException : Exception
    {
        public ModelException(string message) : base(message)
        {
        }

        public ModelException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
