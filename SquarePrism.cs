using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp3
{
    class SquarePrism:Square
    {
        private int height;
        public int Height { get => height; set => height = value == 0 ? 1 : value; }


        public SquarePrism()
        {
        }


        public SquarePrism(int height, int side)
        {
            Height = height;
            Side = side;
        }


        public double DiagonalOfSide(int height, int side) => Math.Sqrt((Math.Pow((double)side, 2) + Math.Pow((double)height, 2)));


        public int SizePrism(int height, int area) => height * area;


        public double SizePrism(double height, int area) => height * area;


        public double DiagonalPrism(int height, int side) => Math.Sqrt(Math.Pow(side, 2) + Math.Pow(DiagonalOfSide(Height, Side), 2));


        public override string ToString()
        {
            return "\nHeight: " + Height + "\nBottom Side: " + Side + "\nSize: " + SizePrism(Height, Area(Side)) + "\nDiagonal of Prism: " + DiagonalPrism(Height, Side);
        }
    }
}
