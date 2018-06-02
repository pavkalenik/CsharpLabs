using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp2
{
    public class Series
    {
        public delegate void MethodContainer1();
        public delegate void MethodContainer2();
        public delegate void MethodContainer3();

        public event MethodContainer1 eventAdd;
        public event MethodContainer2 eventRemove;
        public event MethodContainer3 eventChangeData;

        List<Function> someSeries = new List<Function>();

        public Series(){}

        public Series(Function equation)
        {
            someSeries.Add(equation);
            eventAdd();
        }

        public void AddSeries(Function equation)
        {
            someSeries.Add(equation);
            eventAdd();
        }

        public void Remove(int index)
        {
            if (index < 0 || index >= someSeries.Count)
                throw new MyIndexOutOfRange();
            someSeries.RemoveAt(index);
            eventRemove();
        }

        public void Print()
        {
            foreach (Function element in someSeries)
            {
                element.ToString(2);
                Console.WriteLine();
            }
        }

        public List<Function> DeepCopy()
        {
            List<Function> someSeries2 = new List<Function>();
            foreach (Function element in someSeries)
            {
                if (element is Ellipse)
                {
                    Ellipse equation = new Ellipse(element.A, element.B);
                    someSeries2.Add(equation);
                }
                if (element is Hiperbola)
                {
                    Hiperbola equation = new Hiperbola(element.A, element.B);
                    someSeries2.Add(equation);
                }
                if (element is Parabola)
                {
                    Parabola equation = new Parabola(element.A, element.B, element.C);
                    someSeries2.Add(equation);
                }
            }

            return someSeries2;
        }

        public void ChangeData(int index, double a, double b)
        {
            if (index < 0 || index >= someSeries.Count)
                throw new MyIndexOutOfRange();
            int i = 0;
            foreach (Function element in someSeries)
            {
                if (i == index)
                {
                    if (element is Ellipse)
                    {
                        element.A = a;
                        element.B = b;
                        element.Calculation(element.A);
                        eventChangeData();
                    }
                    else if(element is Hiperbola)
                    {
                        element.A = a;
                        element.B = b;
                        element.Calculation(element.A);
                        eventChangeData();
                    }
                    else
                        Console.WriteLine("Недопустимый индекс: ");
                    break;
                }

                i++;
            }

        }

        public void ChangeData(int index, double a, double b, double c)
        {
            if (index < 0 || index >= someSeries.Count)
                throw new MyIndexOutOfRange();
            int i = 0;
            foreach (Function element in someSeries)
            {
                if (i == index)
                {
                    if (element is Parabola)
                    {
                        element.A = a;
                        element.B = b;
                        element.C = c;
                        element.Calculation(element.A);
                        eventChangeData();
                    }
                    else
                        Console.WriteLine("Недопустимый индекс для изминения данных. Данные не меняются!");
                    break;
                }

                i++;
            }


        }
    }
    class MessageAdd
    {
        public void Message()
        {
            Console.WriteLine("Добавлен новый элемент в коллекцию");
        }
    }
    class MessageRemove
    {
        public void Message()
        {
            Console.WriteLine("Удален элемент в коллекции");
        }
    }
    class MessageChangeData
    {
        public void Message()
        {
            Console.WriteLine("Изменены данные элемента в коллекции");
        }
    }
}
