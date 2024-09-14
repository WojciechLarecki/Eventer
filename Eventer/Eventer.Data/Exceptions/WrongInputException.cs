using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventer.Data.Exceptions
{
    public class WrongInputException : ArgumentException
    {
        public WrongInputException(string? message) : base(message)
        {
        }
    }
}
