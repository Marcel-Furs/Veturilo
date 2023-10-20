using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veturilo.Application.Exceptions
{
    public class OperationException : Exception
    {
        public OperationException(string message) : base(message)   
        {

        }
    }
}
