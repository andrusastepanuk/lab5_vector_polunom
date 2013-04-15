using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Text.RegularExpressions;

namespace LAB5_vector
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (Checking(textBox1.Text) && Checking(textBox2.Text) && Checking(textBox3.Text))
            {
                Vector myVector1 = new Vector(Convert.ToDouble(textBox1.Text),Convert.ToDouble(textBox2.Text),Convert.ToDouble(textBox3.Text));
                if (Checking(textBox4.Text) && Checking(textBox5.Text) && Checking(textBox6.Text))
                {
                    Vector myVector2 = new Vector(Convert.ToDouble(textBox4.Text), Convert.ToDouble(textBox5.Text), Convert.ToDouble(textBox6.Text));

                    if (myVector1 != null && myVector2 != null)
                    {
                        textBox7.Text = (myVector1 + myVector2).ToString();
                        textBox8.Text = (myVector1 - myVector2).ToString();
                        if (Checking(textBox12.Text))
                        {
                            double number = Convert.ToDouble(textBox12.Text);
                            textBox9.Text = (myVector1 * number).ToString();
                            textBox10.Text = (myVector1 / number).ToString();
                        }
                        else MessageBox.Show("Число заданно неверно");
                        textBox11.Text = Convert.ToString(myVector1 * myVector2);
                    }
                    else MessageBox.Show("Векторы заданы неверно");
                }
            }
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            //многочлены задаються случайным образом
            Random random = new Random();
            Polynomial myPolynomial1 = Polynomial.Random(random);
            Polynomial myPolynomial2 = Polynomial.Random(random);
            MessageBox.Show("Первый: " + myPolynomial1.ToString() + "\nВторой: " + myPolynomial2.ToString() + "\nСумма: " + (myPolynomial1 + myPolynomial2).ToString(), "Сложение");
            MessageBox.Show("Первый: " + myPolynomial1.ToString() + "\nВторой: " + myPolynomial2.ToString() + "\nРазность: " + (myPolynomial1 - myPolynomial2).ToString(), "Разность");
            MessageBox.Show("Первый: " + myPolynomial1.ToString() + "\nВторой: " + myPolynomial2.ToString() + "\nПроизведение: " + (myPolynomial1 * myPolynomial2).ToString(), "Умножение");
        }

        private bool Checking(string text)
        {
            Regex regex = new Regex(@"^\d*(\,\d+)?$");
            Match match = regex.Match(text);
            return (text == "") ? false : match.Success;
        }
    }
}
