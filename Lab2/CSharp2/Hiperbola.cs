using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp2
{
    public class Hiperbola : Function
    {
        public Hiperbola() { }

        public Hiperbola(double a, double b)
        {
            this.a = a;
            this.b = b;
        }

        public override void ToString(double x)
        {
            Console.WriteLine("Hiperbole: ({0:0.0}, {1:0.0}, {2:0.0}) = {3:0.00}", a, b, x, Calculation(x));
        }

        public override double Calculation(double x)
        {
            if (x * x - a * a < 0)
                throw new MyInvalidOperationException();
            return b / a * Math.Sqrt(x * x - a * a);
        }


       
    }
}
