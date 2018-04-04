using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes_task_7
{    
    public class Program
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

        static void Main(string[] args)
        {
            try
            {
                int n;
                Console.WriteLine("enter n(size of array from 0 to n)");
                if(!(Int32.TryParse(Console.ReadLine(), out n)))
                {
                    throw new ArgumentException();
                }

                List<ComplexNumber> a = new List<ComplexNumber>();
                Console.WriteLine("a:");
                for (int i = 0; i <= n; i++)
                {
                    ComplexNumber c = new ComplexNumber();
                    c.Input();
                    a.Add(c);
                }
                List<ComplexNumber> b = new List<ComplexNumber>();
                Console.WriteLine("b:");
                for (int i = 0; i <= n; i++)
                {
                    ComplexNumber c = new ComplexNumber();
                    c.Input();
                    b.Add(c);
                }

                List<ComplexNumber> sum = Sum(a, b);
                Console.WriteLine("a + b:");
                for (int i = 0; i <= n; i++)
                {
                    sum[i].Print();
                }
                List<ComplexNumber> sub = Subtraction(a, b);
                Console.WriteLine("a - b:");
                for (int i = 0; i <= n; i++)
                {
                    sub[i].Print();
                }
                ComplexNumber mul = Multiplication(a, b);
                Console.WriteLine("a * b:");
                mul.Print();
            }
            catch(ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
