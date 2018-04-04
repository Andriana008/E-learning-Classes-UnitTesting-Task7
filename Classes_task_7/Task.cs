using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes_task_7
{
    public class Task
    {
        public static List<ComplexNumber> Sum(List<ComplexNumber> c1, List<ComplexNumber> c2)
        {
            List<ComplexNumber> sum = new List<ComplexNumber>();
            for (int i = 0; i < c1.Count; i++)
            {
                ComplexNumber c = c1[i] + c2[i];
                sum.Add(c);
            }
            return sum;
        }

        public static List<ComplexNumber> Subtraction(List<ComplexNumber> c1, List<ComplexNumber> c2)
        {
            List<ComplexNumber> sum = new List<ComplexNumber>();
            for (int i = 0; i < c1.Count; i++)
            {
                ComplexNumber c = c1[i] - c2[i];
                sum.Add(c);
            }
            return sum;
        }

        public static ComplexNumber Multiplication(List<ComplexNumber> c1, List<ComplexNumber> c2)
        {
            ComplexNumber mul = new ComplexNumber();
            for (int i = 0; i < c1.Count; i++)
            {
                mul += c1[i] * c2[i].GetConjugate();
            }
            return mul;
        }

        public static void InputList(ref List<ComplexNumber> l, int n)
        {
            for (int i = 0; i <= n; i++)
            {
                Console.WriteLine("enter re,im for this complex number");
                Console.Write("enter re:");
                if (!(Double.TryParse(Console.ReadLine(), out double re)))
                {
                    throw new ArgumentException();
                }
                Console.Write("enter im:");
                if (!(Double.TryParse(Console.ReadLine(), out double im)))
                {
                    throw new ArgumentException();
                }

                ComplexNumber c = new ComplexNumber(re, im);
                l.Add(c);
            }
        }

        public static void PrintList(List<ComplexNumber> l)
        {
            for (int i = 0; i < l.Count(); i++)
            {
                if (l[i].Im < 0) Console.WriteLine($"{l[i].Re}{l[i].Im}i");
                else Console.WriteLine($"{l[i].Re}+{l[i].Im}i");
            }
        }

        public static void DoTask(List<ComplexNumber> a, List<ComplexNumber> b)
        {
            List<ComplexNumber> sum = Sum(a, b);
            Console.WriteLine("a + b:");
            PrintList(sum);
            List<ComplexNumber> sub = Subtraction(a, b);
            Console.WriteLine("a - b:");
            PrintList(sub);
            ComplexNumber mul = Multiplication(a, b);
            Console.WriteLine("a * b:");
            Console.WriteLine($"{mul.Re}+{mul.Im}i");
        }

    }
}
