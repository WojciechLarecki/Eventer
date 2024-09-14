using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventer.Data.Exceptions
{
    public class NotFoundInDBException : Exception
    {
        public NotFoundInDBException(string? message) : base(message)
        {
        }

        public NotFoundInDBException(string ObjectType, object objectId) 
            : base($"{ObjectType} with id {objectId} could not be found in Database.")
        {
        }
    }
}
