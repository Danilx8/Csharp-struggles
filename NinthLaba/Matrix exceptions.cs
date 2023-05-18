using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TenthLaba
{
    public class InvalidMatrixException : Exception
    {
        public InvalidMatrixException() { }
        public InvalidMatrixException(string Message) : base(Message) { }
        public InvalidMatrixException(string Message, Exception Inner) :
            base(Message, Inner)
        { }
    }
}
