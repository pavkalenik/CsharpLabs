using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp2
{
    class Program
    {
        public static void Main(string[] args)
        {
            MessageAdd Handler1 = new MessageAdd();
            MessageRemove Handler2 = new MessageRemove();
            MessageChangeData Handler3 = new MessageChangeData();
            Series ser = new Series();
            ser.eventAdd += Handler1.Message;
            ser.eventRemove += Handler2.Message;
            ser.eventChangeData += Handler3.Message;
            ser.AddSeries(new Hiperbola(1, 2));
            ser.AddSeries(new Ellipse(10, 8));
            ser.AddSeries(new Hiperbola(1, 2));
            ser.AddSeries(new Ellipse(10, 8));
            ser.AddSeries(new Parabola(5, -2, 7));
            ser.Remove(2);
            ser.ChangeData(1, 7, 9);
            Console.WriteLine("\n" + "Series consist of:");
            ser.Print();
            Test(ser);
        }

        public static void Test(Series ser)
        {
            Ellipse equation = new Ellipse(10, 8);
            Hiperbola equation2 = new Hiperbola(1, 2);
            Parabola equation3 = new Parabola(5, -2, 7);
            if (equation.Equals(new Ellipse(10, 8)) && equation2.Equals(new Hiperbola(1, 2)) && equation3.Equals(new Parabola(5, -2, 7)))
                Console.WriteLine("Equals is correct");
            else
                Console.WriteLine("Equals is not correct");

            Hiperbola equation4 = new Hiperbola(1, 2);
            Ellipse equation5 = new Ellipse(10, 8);
            Parabola equation6 = new Parabola(5, -2, 7);
            if (equation == equation5 && equation2 == equation4 && equation3 == equation6)
                Console.WriteLine("== and != is correct");
            else
                Console.WriteLine("== and != is not correct");

            if (equation.GetHashCode() == equation5.GetHashCode())
                Console.WriteLine("GetHashCode is correct");
            else
                Console.WriteLine("GetHashCode is not correct");

            Console.WriteLine("\n" + "Тест DeepCopy: " + "\n");

            List<Function> someSeries2 = new List<Function>();
            someSeries2 = ser.DeepCopy();
            foreach (Function element in someSeries2)
            {
                element.ToString(2);
            }
            Console.Write("\n" + "Нажмите любую кнопку...");
            Console.ReadKey();
        }
    }
}
