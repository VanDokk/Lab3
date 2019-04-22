using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public string path = null;
        public bool flag = false;
        public bool s = false;
        public int i = 0;
        public int amountOfSquares = 0;
        public int amountOfPrisms = 0;
        List<Square> squares = new List<Square>();
        List<SquarePrism> prisms = new List<SquarePrism>();




        private void button1_Click(object sender, EventArgs e)
        {
            flag = false;
            path = textBox1.Text;


            try
            {
                using (var MyFile = File.Open(path, FileMode.OpenOrCreate)) { }
                flag = true;
            }
            catch
            {
                MessageBox.Show("Не верный путь");
            }
            finally
            {
                textBox1.Text = null;
            }


            if (flag == true)
            {
                textBox2.Text.Replace(" ", "");
                try
                {
                    Convert.ToInt32(textBox2.Text);
                    using (StreamWriter sw = new StreamWriter(path, false))
                    {
                        sw.WriteLine(textBox2.Text);
                    }
                }
                catch
                {
                    MessageBox.Show("Не верные данные");
                    flag = false;
                }
                finally
                {
                    textBox2.Text = null;
                }
            }

            if (flag == true)
            {
                textBox3.Text.Replace(" ", "");
                try
                {
                    Convert.ToInt32(textBox3.Text);
                    using (StreamWriter sw = new StreamWriter(path, true))
                    {
                        sw.WriteLine(textBox3.Text);
                    }
                    s = true;
                }
                catch
                {
                    MessageBox.Show("Не верные данные");
                }
                finally
                {
                    textBox3.Text = null;
                }
            }
            if (s == true)
            {
                textBox1.Visible = textBox2.Visible = textBox3.Visible = label1.Visible = label2.Visible = label3.Visible = button1.Visible = false;
                textBox4.Visible = label4.Visible = button2.Visible = true;
                using (StreamReader sr = new StreamReader(path))
                {
                    amountOfSquares = Convert.ToInt32(sr.ReadLine());
                    amountOfPrisms = Convert.ToInt32(sr.ReadLine());
                }
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            if (i < amountOfSquares)
            {
                label4.Text = (i + 2) % 10 == 3 ? "Введите сторону " + (i + 2) + "-его " + "квадрата" : "Введите сторону " + (i + 2) + "-ого " + "квадрата";
                try
                {
                    squares.Add(new Square(Convert.ToInt32(textBox4.Text)));
                    i++;
                }
                catch
                {
                    MessageBox.Show("Не верные данные");                    
                }
                finally
                {
                    textBox4.Text = null;
                }
            }
            if (i >= amountOfSquares)
            {
                label4.Visible = textBox4.Visible = button2.Visible = false;
                label1.Visible = textBox1.Visible = label2.Visible = textBox2.Visible = button3.Visible = true;
                label1.Text = "Введите длину высоты для первой призмы";
                label2.Text = "Введите длину стороны основания для первой призмы";
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            label1.Text = (i - amountOfPrisms + 2) % 10 == 3 ? "Введите длину высоты для " + (i - amountOfPrisms + 2) + "-ей призмы" : "Введите длину высоты для " + (i - amountOfSquares + 2) + "-ой призмы";
            label2.Text = (i - amountOfPrisms + 2) % 10 == 3 ? "Введите длину стороны основания для " + (i - amountOfPrisms + 2) + "-ей призмы" : "Введите длину стороны основания для " + (i - amountOfSquares + 2) + "-ой призмы";
            try
            {
                prisms.Add(new SquarePrism(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text)));
                i++;
            }
            catch
            {
                MessageBox.Show("Не верные данные");                
            }
            finally
            {
                textBox1.Text = textBox2.Text = null;
            }
            if (i - amountOfSquares == amountOfPrisms)
            {                
                button3.Visible = label5.Visible = textBox5.Visible = label4.Visible = textBox4.Visible = textBox1.Visible = textBox2.Visible = label1.Visible = label2.Visible = false;
                button4.Visible = true;     
                
            }            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Visible = textBox2.Visible = label1.Visible = label2.Visible = label5.Visible = textBox5.Visible = label4.Visible = textBox4.Visible = true;
            label1.Text = "Максимальная площадь у квадрата под номером:";
            label2.Text = "Его площадь равна: ";
            label5.Text = "Максимальная диагональ у призмы под номером:";
            label4.Text = "Ее диагональ равна:";

            int max1 = squares[0].Area(squares[0].Side);
            int k = 0;
            for (int i = 1; i < amountOfSquares; i++)
            {
                if (max1 < squares[i].Area(squares[i].Side))
                {
                    max1 = squares[i].Area(squares[i].Side);
                    k = i;
                }
            }
            textBox1.Text = Convert.ToString(k);
            textBox2.Text = Convert.ToString(max1);
            textBox1.Enabled = textBox2.Enabled = button4.Enabled = false;

            k = 0;
            double max2 = prisms[0].DiagonalPrism(prisms[0].Height,prisms[0].Side);
            for (int i = 1; i < amountOfPrisms; i++)
            {
                if (max2 < prisms[i].DiagonalPrism(prisms[i].Height, prisms[i].Side))
                {
                    max2 = prisms[i].DiagonalPrism(prisms[i].Height, prisms[i].Side);
                    k = i;
                }
            }
            textBox5.Text = Convert.ToString(k);
            textBox4.Text = Convert.ToString(max2);
            textBox4.Enabled = textBox5.Enabled = button4.Visible = false;
        }
    }


}



//C:\Users\Игорь\source\repos\WindowsFormsApp3\WindowsFormsApp3\bin\Debug\test.txt