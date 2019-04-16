using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    class Fraction
    {
        private int numerator;
        private int denominator;

        public int Denominator { get => denominator; set => denominator = value; }
        public int Numerator { get => numerator; set => numerator =  value; }

        public Fraction()
        {
            Denominator = 1;
            Numerator = 1;
        }
        public Fraction(int numerator)
        {
            Denominator = 1;
            Numerator = numerator;
        }
        public Fraction (int numerator, int denominator)
        {
            Denominator = denominator;
            Numerator = numerator;

        }

        public  static int Nod(int numerator, int denominator)
        {
            int i = 0;
            int nod = 0;
            bool flag = false;
            numerator = Math.Abs(numerator);
            denominator = Math.Abs(denominator);
            if (denominator == numerator)
                return numerator;
            else
            {
                if (numerator < denominator)
                    for (i = numerator / 2; i > 2; i--)
                    {
                        if ((numerator % i == 0) && (denominator % i == 0))
                        {                            
                            flag = true;
                            break;
                        }                    
                    }
                else
                    for (i = denominator / 2; i > 2; i--)
                        if ((numerator % i == 0) && (denominator % i == 0))
                        {                            
                            flag = true;
                            break;
                        }
                if (flag == false)
                    return 0;
                else
                    return i;
            }
            
        }

        public static Fraction operator +(Fraction f1, Fraction f2)
        {
            if (f1.Denominator == f2.Denominator)
                return new Fraction(f1.Numerator + f2.Numerator, f1.Denominator);
            else
                return new Fraction(f1.Numerator * ((f1.Denominator * f2.Denominator) / f1.Denominator) + ((f1.Denominator * f2.Denominator) / f2.Denominator) * f2.Numerator, f1.Denominator * f2.Denominator);
        }

        public static Fraction operator -(Fraction f1, Fraction f2)
        {
            if (f1.Denominator == f2.Denominator)
                return new Fraction(f1.Numerator - f2.Numerator, f1.Denominator);
            else
                return new Fraction(f1.Numerator * ((f1.Denominator * f2.Denominator) / f1.Denominator) - ((f1.Denominator * f2.Denominator) / f2.Denominator) * f2.Numerator, f1.Denominator * f2.Denominator);
        }

        public static Fraction operator *(Fraction f1,Fraction f2)
        {
            return new Fraction(f1.Numerator * f2.Numerator, f1.Denominator * f2.Denominator);
        }

        public static Fraction operator /(Fraction f1, Fraction f2)
        {
            return new Fraction(f1.Numerator * f2.Denominator, f1.Denominator * f2.Numerator);
        }

        public override string ToString()
        {
            return "\nFraction: " + Numerator + "\n        --------\n" + "           " + Denominator;
        }


























    }
}
