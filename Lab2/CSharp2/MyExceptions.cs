using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp2
{
    public class MyExceptions : Exception
    {
        public MyExceptions()
        {
            Console.WriteLine("Коефициант a не должен быть равен нулю!");
        }
    }

    public class MyInvalidOperationException : Exception
    {
        public MyInvalidOperationException()
        {
            Console.WriteLine("Неверно заданы полуоси!");
        }
    }

    public class MyIndexOutOfRange : Exception
    {
        public MyIndexOutOfRange()
        {
            Console.WriteLine("Индекс вне диапазона!");
        }
    }

    public class MyZeroException : Exception
    {
        public MyZeroException()
        {
            Console.WriteLine("Деление на ноль!");
        }
    }


}
