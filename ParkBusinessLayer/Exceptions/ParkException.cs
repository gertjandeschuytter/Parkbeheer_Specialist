using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkBusinessLayer.Exceptions
{
    public class ParkException : Exception
    {
        public ParkException(string message) : base(message)
        {
        }

        public ParkException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
