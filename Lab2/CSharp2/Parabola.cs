using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp2
{
    sealed class Parabola : Function
    {
        public Parabola(double a, double b, double c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }

        public override void ToString(double x)
        {
            Console.WriteLine("Parabola: ({0:0.0}, {1:0.0}, {2:0.0}, {3:0.0}) = {4:0.00}", a, b, c, x, Calculation(x));
        }

        public override double Calculation(double x)
        {
            if (a == 0)
            {
                throw new MyExceptions();
            }
            return a * x * x + b * x + c;
        }

    }
}
