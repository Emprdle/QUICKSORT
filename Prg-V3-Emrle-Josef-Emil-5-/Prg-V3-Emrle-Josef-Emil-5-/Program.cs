using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prg_V3_Emrle_Josef_Emil_4
{
    class Program
    {
        static void Main(string[] args)
        {
            double N = 1;
            double s1 = 0;
            double s2 = 0;

            float M = 1;
            float s3 = 0;
            float s4 = 0;
            Console.WriteLine("DOUBLE");
            for (double i = 1; i < 10000; i++)
            {
                s1 = s1 + (N / i);

            }
            Console.WriteLine(s1);

            for (double i = 10000; i > 0; i--)
            {
                s2 = s2 + (1 / (N + i));

            }
            
            Console.WriteLine("---------------");
            Console.WriteLine(s2);
            for (float i = 1; i < 10000; i++)
            {
                s3 = s3 + (M / i);

            }
            Console.WriteLine("FLOAT");
            Console.WriteLine("---------------");
            Console.WriteLine(s3);

            for (float i = 10000; i > 0; i--)
            {
                s4 = s4 + (1 / (M + i));

            }
            Console.WriteLine("---------------");
            Console.WriteLine(s4);

            Console.ReadKey();
        }
    }
}
