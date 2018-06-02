using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp2
{
    public abstract class Function : Object
    {
        protected double a;    
        protected double b;
        protected double c;
        protected double x;
        protected double result;

        public Function()
        {
            a = 0;
            b = 0;
        }

        public Function(double a, double b)
        {
            this.a = a;
            this.b = b;
        }

        public Function(double a, double b, double c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }

        public double A
        {
            get { return a; }
            set { a = value; }
        }

        public double B
        {
            get { return b; }
            set { b = value; }
        }

        public double C
        {
            get { return c; }
            set { c = value; }
        }

        public double Result
        {
            get { return result; }
        }

        public bool Equals(Function equation)
        {
            return a == equation.A && b == equation.B && c == equation.C && result == equation.Result;
        }

        public static bool operator ==(Function equation, Function equation2)
        {
            return equation.Equals(equation2);
        }

        public static bool operator !=(Function equation, Function equation2)
        {
            return !equation.Equals(equation2);
        }

        public override int GetHashCode()
        {
            return (int)a ^ (int)b;
        }

        public abstract void ToString(double x);

        public abstract double Calculation(double x);

    }
}
