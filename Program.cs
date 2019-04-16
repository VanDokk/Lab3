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
            bool flag;
            for (int i = 0; i < 5; i++)
            {
                flag = false;
                do
                {                    
                    Console.WriteLine("Введите числитель и знаменатель дроби");
                    try
                    {
                        fractions[i] = new Fraction(Convert.ToInt32(Console.ReadLine()), Convert.ToInt32(Console.ReadLine()));
                        flag = true;
                    }
                    catch
                    {
                        Console.WriteLine("Не верно введена дробь");
                    }
                } while (flag == false);
            }


            Fraction result = ((fractions[0] + fractions[1]) / fractions[2]) * (fractions[3] - fractions[4]);

            Console.WriteLine(result.ToString());


            int s = Fraction.Nod(result.Numerator, result.Denominator);
            if (s != 0)
            {
                result.Numerator /= s;
                result.Denominator /= s;
                Console.WriteLine(result.ToString());
            }

            
            //Console.WriteLine((double)result.Numerator / result.Denominator);
            Console.ReadLine();



        }
    }
}
