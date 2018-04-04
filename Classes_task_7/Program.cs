using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes_task_7
{
    public class ComplexNumber
    {
        private double re;
        private double im;

        public ComplexNumber() : this(0, 0) { }        

        public ComplexNumber(double _re, double _im)
        {
            re = _re;
            im = _im;
        }

        public void Input()
        {
            Console.WriteLine("enter re,im for this complex number");
            Console.Write("enter re:");
            if(!(Double.TryParse(Console.ReadLine(), out re)))
            {
                throw new ArgumentException();
            }
            Console.Write("enter im:");
            if (!(Double.TryParse(Console.ReadLine(), out im)))
            {
                throw new ArgumentException();
            }
        }

        public void Print()
        {
            if (im < 0) Console.WriteLine($"{re}{im}i");
            else Console.WriteLine($"{re}+{im}i");
        }

        public ComplexNumber GetConjugate()
        {
            return new ComplexNumber(re, -im);
        }

        public static ComplexNumber operator +(ComplexNumber c1, ComplexNumber c2)
        {
            return new ComplexNumber(c1.re + c2.re, c1.im + c2.im);
        }
        public static ComplexNumber operator -(ComplexNumber c1, ComplexNumber c2)
        {
            return new ComplexNumber(c1.re - c2.re, c1.im - c2.im);
        }
        public static ComplexNumber operator *(ComplexNumber c1, ComplexNumber c2)
        {
            return new ComplexNumber(c1.re * c2.re - c1.im * c2.im, c1.re * c2.im + c1.im * c2.re);
        }
        public static ComplexNumber operator /(ComplexNumber c1, ComplexNumber c2)
        {
            if ((c2.re * c2.re + c2.im * c2.im).Equals(0) && (c2.re * c2.re + c2.im * c2.im).Equals(0))
            {
                throw new ArgumentException();
            }
            return new ComplexNumber((c1.re * c2.re + c1.im * c2.im) / (c2.re * c2.re + c2.im * c2.im), (c1.im * c2.re - c1.re * c2.im) / (c2.re * c2.re + c2.im * c2.im));
        }
        public override bool Equals(Object obj)
        {
            if (obj == null) return false;
            if (this.GetType() != obj.GetType()) return false;
            ComplexNumber p = (ComplexNumber)obj;
            if (re.Equals(p.re) && im.Equals(p.im)) return true;
            return false;
        }

        public override int GetHashCode()
        {
            var hashCode = -196947237;
            hashCode = hashCode * -1521134295 + re.GetHashCode();
            hashCode = hashCode * -1521134295 + im.GetHashCode();
            return hashCode;
        }

        public static bool operator ==(ComplexNumber p1, ComplexNumber p2)
        {
            return Object.Equals(p1, p2);
        }
        public static bool operator !=(ComplexNumber p1, ComplexNumber p2)
        {
            return !(p1 == p2);
        }
    }


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
