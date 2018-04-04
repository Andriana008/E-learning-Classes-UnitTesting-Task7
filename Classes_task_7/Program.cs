using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes_task_7
{    
    public class Program
    {             
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("enter n(size of array from 0 to n)");
                if(!(Int32.TryParse(Console.ReadLine(), out int n)))
                {
                    throw new ArgumentException();
                }

                List<ComplexNumber> a = new List<ComplexNumber>();
                Console.WriteLine("a:");
                Task.InputList(ref a, n);

                List<ComplexNumber> b = new List<ComplexNumber>();
                Console.WriteLine("b:");
                Task.InputList(ref b, n);

                Task.DoTask(a,b);
            }
            catch(ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
