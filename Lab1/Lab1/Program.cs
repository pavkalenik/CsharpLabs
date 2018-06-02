/*
 * Варіант 10
 * Андрей работает системным администратором и планирует создание новой сети в своей компании. 
 * Всего будет N хабов, они будут соединены друг с другом с помощью кабелей. 
 * Поскольку каждый сотрудник компании должен иметь доступ ко всей сети, каждый хаб должен быть достижим от любого другого хаба — возможно, через несколько промежуточных хабов. 
 * Поскольку имеются кабели различных типов и короткие кабели дешевле, требуется сделать такой план сети (соединения хабов), чтобы максимальная длина одного кабеля была как можно меньшей. 
 * Есть еще одна проблема — не каждую пару хабов можно непосредственно соединять по причине проблем совместимости и геометрических ограничений здания. 
 * Андрей снабдит вас всей необходимой информацией о возможных соединениях хабов. 
 * Вы должны помочь Андрею найти способ соединения хабов, который удовлетворит всем указанным выше условиям.
 * */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    public class Node
    {
        public int u;
        public int v;
        public int w;
    }

    class Program
    {
        public static readonly int MAXN = 1000;
        public static readonly int MAXM = 15000;
        public static int[] fa = new int[MAXN];
        public static int[] inq = new int[MAXN];
        public static int mmax, en;
        public static Node[] da = Arrays.InitializeWithDefaultInstances<Node>(MAXM);

        public static int Find(int x)
        {
            if (x != fa[x])
            {
                return fa[x] = Find(fa[x]);
            }
            return x;
        }

        public static void Kruskal(int n, int m)
        {
            int i;
            mmax = 0; en = 0;
            for (i = 1; i <= n; i++) fa[i] = i;
            Node temp;
            for (i = 1; i < n; i++)
            {
                for (int j = 1; j <= n - i; j++)
                {
                    if (da[j].w > da[j + 1].w)
                    {
                        temp = da[j];
                        da[j] = da[j + 1];
                        da[j + 1] = temp;
                    }
                }
            }

            for (i = 0; i < m; i++)
            {
                int x = Find(da[i].u);
                int y = Find(da[i].v);
                if (x != y)
                {
                    fa[x] = y;
                    inq[en++] = i;
                    if (da[i].w > mmax) mmax = da[i].w;
                }
                if (en == n - 1) break;
            }
        }

        public static void Main(string[] args)
        {
            int n, m, i, choise;
            while (true)
            {
                try
                {
                    Console.WriteLine("1 - Ввод с клавиатуры.");
                    Console.WriteLine("2 - Рандомное заполнение.");
                    Console.Write("Введите число: ");
                    choise = Convert.ToInt32(Console.ReadLine());
                    if (choise == 1)
                    {
                        Console.Write("Количество хабов в сети: ");
                        n = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Количество возможных соединений хабов: ");
                        m = Convert.ToInt32(Console.ReadLine());
                        for (i = 0; i < m; i++)
                        {
                            Console.Write("Номер первого хаба: ");
                            da[i].u = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Номер второго хаба: ");
                            da[i].v = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Длина кабеля: ");
                            da[i].w = Convert.ToInt32(Console.ReadLine());
                        }
                        break;
                    }
                    else if (choise == 2)
                    {
                        Random Rnd = new Random();
                        n = Rnd.Next(1, 1000);
                        m = Rnd.Next(1, 15000);
                        for (i = 0; i < m; i++)
                        {
                            da[i].u = Rnd.Next(1, 1000);
                            da[i].v = Rnd.Next(1, 1000);
                            da[i].w = Rnd.Next(1, 1000);
                        }
                        break;
                    }
                }
                catch (FormatException)
                {
                    Console.Write("Неверный ввод! " + "Повторите ввод снова! \n");
                }
            }
            Kruskal(n, m);
            Console.Write("\n" + "Максимальная длина одного кабеля: " + mmax + "\n" + "Количество кабелей, которые использовались: " + en + "\n" + "Номера хабов, непосредственно соединенных в моем плане кабелями:" + "\n" + "\n");
            for (i = 0; i < en; i++)
            {
                Console.Write(da[inq[i]].u + " - ");
                Console.Write(da[inq[i]].v + "\n");
            }
            Console.WriteLine("\n" + "Нажмите любую кнопку...");
            Console.ReadKey();

        }
    }

    internal static class Arrays
    {
        internal static T[] InitializeWithDefaultInstances<T>(int length) where T : new()
        {
            T[] array = new T[length];
            for (int i = 0; i < length; i++)
            {
                array[i] = new T();
            }
            return array;
        }
    }

}
