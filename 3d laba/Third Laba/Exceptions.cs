using System;

namespace Third_Laba
{
    public class InvalidMatrixException: Exception
    {
        public InvalidMatrixException() { }
        public InvalidMatrixException(string Message) : base(Message) { }
        public InvalidMatrixException(string Message, Exception Inner):
            base(Message, Inner) { }
    }
}