using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        Fraction[] fractions = new Fraction[5];

        public Form1()
        {
            InitializeComponent();
        }

        int i = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            textBox3.Text = textBox3.Text.Replace(" ", "");
            textBox1.Text = textBox1.Text.Replace(" ", "");
            bool flag = false;
            

            try
            {
                Convert.ToInt32(textBox3.Text);
                Convert.ToInt32(textBox1.Text);
                

                if (Convert.ToInt32(textBox1.Text) == 0)
                    MessageBox.Show("Знаменатель не может быть = 0");
                else
                    flag = true;
                
            }
            catch
            {
                MessageBox.Show("Не верный формат данных");                
            }

            if (flag == true)
            {
                fractions[i] = new Fraction(Convert.ToInt32(textBox3.Text), Convert.ToInt32(textBox1.Text));                
                i++;


                string frac = " дробь";
                label4.Text = i == 1 ? "Вторая" + frac : i == 2 ? "Третья" + frac : i == 3 ? "Четвертая" + frac : i == 4 ? "Пятая" + frac : null;
                textBox1.Text = null;
                textBox3.Text = null;
            }

            if (i == 5)
            {
                Fraction result = ((fractions[0] + fractions[1]) / fractions[2]) * (fractions[3] - fractions[4]);

                label4.Text = "Результат: ";
                textBox1.Text = Convert.ToString(result.Denominator);
                textBox3.Text = Convert.ToString(result.Numerator);
                i++;      
                
                if (i == 6)
                {
                                        
                    int s = Fraction.Nod(result.Numerator, result.Denominator);
                    if (s != 0)
                    {
                        label1.Visible = textBox2.Visible = textBox4.Visible = button2.Visible = true;                        
                        textBox4.Text = Convert.ToString(result.Denominator/s);
                        textBox2.Text = Convert.ToString(result.Numerator/s);
                        textBox1.Enabled = textBox2.Enabled = textBox3.Enabled = textBox4.Enabled = false;
                        button1.Visible = false;
                        
                    }
                    else
                    {
                        textBox1.Enabled = textBox3.Enabled = false;
                        button2.Visible = true;
                        button1.Visible = false;

                    }
                    
                }
            }
            


        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}


/*Fraction[] fractions = new Fraction[5];
bool flag;
            for (int i = 0; i< 5; i++)
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
            Console.ReadLine(); */