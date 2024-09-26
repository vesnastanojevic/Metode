using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zad1
{
  
    class Program
    {
        static int NZD( int a, int b)
        {
            int r;
            do
            {
                r = a % b;
                a = b; b = r;
            } while (b > 0);
            return a;
        }

        static void Unazad(int n)
        {
            while (n > 0)
            {
                Console.Write(n % 10);
                n /= 10;
            }
            Console.WriteLine();
        }
        static bool Prost(int n)
        {
            if (n <= 1) { return false; }
            if (n == 2) { return true; }
            if (n % 2 == 0) { return false; }
            int L = (int)Math.Sqrt(n);
            for (int d = 3; d <= L; d += 2)
            {
                if (n % d == 0) { return false; }
            }
            return true;
        }

        static int BUP(int n)
        {
            int br = 1;
           
            for (int i = 2; i < n; i++)
            {
                if (NZD(n, i) == 1)
                {
                    br++;
                }
            }
            return br;
        } // BUP

        static void Main(string[] args)
        {
            int n, br, i;
            Program p = new Program();
            Console.Write("n -> ");
            n = int.Parse(Console.ReadLine());
            br = 1;
            for (i = 2; i < n; i++)
            {
                if (NZD(n, i) == 1)
                {
                    br++;
                }

            }
            Console.WriteLine(br);

            Console.Write("BUP ");
            Console.ReadLine();
            Console.WriteLine(BUP(n));

            Console.Write("Unazad ");
            Console.ReadLine();
            for (i = 1; i <= n; i++)
            {
                Unazad(i);
            }

            Console.Write("Prost ");
            if (Prost(n))
            {
                Console.WriteLine("Broj je prost");
            }
            else
            {
                Console.WriteLine("Broj nije prost");
            }

            Console.ReadKey();

        }
    }
}
