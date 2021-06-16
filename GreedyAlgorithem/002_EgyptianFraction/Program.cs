using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _002_EgyptianFraction
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * Egyptian Fraction Representation of 2/3 is 1/2 + 1/6
             * Egyptian Fraction Representation of 6/14 is 1/3 + 1/11 + 1/231
             * Egyptian Fraction Representation of 12/13 is 1/2 + 1/3 + 1/12 + 1/156
             */
            FindEgyptianFraction(12, 13, 2);
        }
        public static void FindEgyptianFraction(int a, int b, int d)
        {
            if (a == 0 || b == 0)
            {
                Console.WriteLine(0);
                return;
            }
            if (a>b)
            {
                Console.WriteLine(a/b);
                a = a%b;
            }
            if (b % a == 0)
            {
                Console.WriteLine("1/"+b/a);
                return;
            }
            if ((d*a - b) > 0)
            {
                Console.WriteLine("1/"+d);
                a = d * a -b;
                b = b * d;
            }
            FindEgyptianFraction(a, b, d+1);
        }
    }
}
