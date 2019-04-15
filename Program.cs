using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            Fraction[] fractions = new Fraction[5];
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Введите числитель и знаменатель дроби");
                fractions[i] = new Fraction(Convert.ToInt32(Console.ReadLine()), Convert.ToInt32(Console.ReadLine()));
            }


            Fraction result = ((fractions[0] + fractions[1]) / fractions[2]) * (fractions[3] - fractions[4]);

            Console.WriteLine(result.ToString());


            int s = Fraction.Nod(result.Numerator, result.Denominator);
            if (s != 0)
            {
                result.Numerator /= s;
                result.Denominator /= s;
            }

            Console.WriteLine(result.ToString());
            Console.WriteLine((double)result.Numerator / result.Denominator);
            Console.ReadLine();



        }
    }
}
