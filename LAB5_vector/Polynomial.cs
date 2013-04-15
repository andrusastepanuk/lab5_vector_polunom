using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LAB5_vector
{
    class Polynomial
    {
        private double[] arr;

        public Polynomial(double[] arr)
        {
            this.arr = new double[arr.Length];
            this.arr = (double[])arr.Clone();
            Array.Reverse(this.arr);
        }

        public double this[int i]
        {
            get
            {
                return this.arr[i];
            }
            set
            {
                if ((i >= 0) && (i < arr.Length))
                    this.arr[i] = value;
                else throw new Exception("выход за пределы массива");
            }
        }

        public static Polynomial operator +(Polynomial firstPolynomial, Polynomial secondPolynomial)
        {
            int firstLength = firstPolynomial.arr.Length, secondLength = secondPolynomial.arr.Length;
            double[] myArr = new double[(secondLength > firstLength) ? firstLength : secondLength];
            int i = 0;
            for (i = 0; i < ((secondLength > firstLength) ? firstLength : secondLength); i++)
                myArr[i] = firstPolynomial[i] + secondPolynomial[i];
            //дописываю оставшееся
            for (int j = i; j < ((secondLength > firstLength) ?  secondLength: firstLength); j++)
                myArr[j] = (secondLength > firstLength) ? secondPolynomial[j] : firstPolynomial[j];
            Array.Reverse(myArr);
            return new Polynomial(myArr);
        }

        public static Polynomial operator -(Polynomial firstPolynomial, Polynomial secondPolynomial)
        {
            int firstLength = firstPolynomial.arr.Length, secondLength = secondPolynomial.arr.Length;
            double[] myArr = new double[(secondLength > firstLength) ? firstLength : secondLength];
            int i;
            for (i = 0; i < ((secondLength > firstLength) ? firstLength : secondLength); i++)
                myArr[i] = firstPolynomial[i] - secondPolynomial[i];
            //дописываю оставшееся
            for (int j = i; j < ((secondLength > firstLength) ? secondLength : firstLength); j++)
                myArr[j] = (secondLength > firstLength) ? secondPolynomial[j] : firstPolynomial[j];
            Array.Reverse(myArr);
            return new Polynomial(myArr);
        }

        public static Polynomial operator *(Polynomial firstPolynomial, Polynomial secondPolynomial)
        {
            double[] myArr = new double[firstPolynomial.arr.Length + secondPolynomial.arr.Length-1];
            for (int i = 0; i < secondPolynomial.arr.Length; i++)
                for (int j = 0; j < firstPolynomial.arr.Length; j++)
                    myArr[i + j] += secondPolynomial[i] * firstPolynomial[j];
            Array.Reverse(myArr);
            return new Polynomial(myArr);
        }

        public static Polynomial Random(Random random)
        {
            double[] myArr = new double[random.Next(5)];
            for (int i = 0; i < myArr.Length; i++)
                myArr[i] = (random.NextDouble() - 0.5) * 10;
            Array.Reverse(myArr);
            return new Polynomial(myArr);
        }

        public override string ToString()
        {
            StringBuilder tempString = new StringBuilder("");
                for (int i = 0; i < arr.Length;i++ )
                    tempString.Append(arr[i].ToString("F5") + "X^"+i.ToString()+"+");
            return tempString.ToString();
        }
    }
}
