using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventer.Logic.Validators
{
    public static class CommonValidator
    {
        public static void CheckIfNotNull<T>(T? date)
        {
            if (date == null)
            {
                var type = typeof(T);
                throw new ArgumentNullException($"Object of type {type} cannot be null.");
            }
        }
    }
}
