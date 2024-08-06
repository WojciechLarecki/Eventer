using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventer.Logic
{
    public class CSVWriter
    {
        private readonly StringBuilder _sb = new StringBuilder();
        private const string separator = ";";

        public void Write(params string[] values)
        {
            for (int i = 0; i < values.Length; i++)
            {
                _sb.Append(values[i]);
                
                // skip appending separator to last element
                if (i < values.Length - 1) 
                {
                    _sb.Append(separator);
                }
            }
        }

        public void WriteLine(params string[] values)
        {
            Write(values);
            _sb.AppendLine();
        }

        public string Content => _sb.ToString();
    }
}
