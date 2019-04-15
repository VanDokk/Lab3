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

        public int Denominator { get => denominator; set => denominator = (denominator != 0) ? 1 : value; }
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
            numerator = Math.Abs(numerator);
            denominator = Math.Abs(denominator);
            while (denominator != 0 && numerator != 0)
            {
                if (numerator % denominator > 0)
                {
                    var temp = numerator;
                    numerator = denominator;
                    denominator = temp % denominator;
                }
                else break;
            }
            if (denominator != 0 && numerator != 0) return denominator;
            return 0;

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
                return new Fraction(f1.Numerator * f2.Denominator - f1.Denominator * f2.Numerator, f1.Denominator * f2.Denominator);
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
