using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp2
{
    public class Ellipse : Function
    {
        public Ellipse(double a, double b)
        {
            this.a = a;
            this.b = b;
        }

        public Ellipse(){}

        public override void ToString(double x)
        {
            Console.WriteLine("Ellipse: ({0:0.0}, {1:0.0}, {2:0.0}) = {3:0.00}", a, b, x, Calculation(x));
        }

        public override double Calculation(double x)
        {
            if (Math.Abs(a) < 1e-8)
            {
                throw new MyZeroException();
            }
            if (1 - x * x / a / a < 0)
            {
                throw new MyInvalidOperationException();
            }
            return b * Math.Sqrt(1 - x * x / a / a);
        }

    }
}
