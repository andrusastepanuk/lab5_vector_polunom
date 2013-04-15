using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace LAB5_vector
{
    class Vector
    {
        public double x{get;private set;}
        public double y { get; private set; }
        public double z { get; private set; }

        public Vector(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public double this[int i]
        {
            get
            {
                return (i == 0) ? x : (i == 1) ? y : z;
            }
            set
            {
                if (i == 0) x = value;
                else if (i == 1) y = value;
                else if (i == 2) z = value;
                else throw new Exception("выход за пределы вектора");
            }
        }

        public static Vector operator +(Vector firstVector, Vector secondVector)
        {
            return new Vector(firstVector.x + secondVector.x, firstVector.y + secondVector.y, firstVector.z + secondVector.z);
        }

        public static Vector operator -(Vector firstVector, Vector secondVector)
        {
            return new Vector(firstVector.x-secondVector.x,firstVector.y-secondVector.y,firstVector.z-secondVector.z);
        }

        public static Vector operator *(Vector vector, double number)
        {
            return new Vector(number*vector.x,number*vector.y,number*vector.z);
        }

        public static Vector operator /(Vector vector, double number)
        {
            return vector * (1.0 / number);
        }

        public static double operator *(Vector firstVector, Vector secondVector)
        {
            return firstVector.x * secondVector.x + firstVector.y * secondVector.y + firstVector.z * secondVector.z;
        }

        public override string ToString()
        {
            return "(" + x + ";" + y + ";" + z + ")";
        }
    }
}
