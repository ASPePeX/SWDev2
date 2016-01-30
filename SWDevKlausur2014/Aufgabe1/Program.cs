using System;

namespace Aufgabe1
{
    class Program
    {
        private static double DoubleMul(double a, double b)
        {
            return a * b;
        }

        private static double DoubleAdd(double a, double b)
        {
            return a + b;
        }

        static void Main(string[] args)
        {
            // Listing 1
            Vector3 v1 = new Vector3 { x = 1.0, y = 2.0, z = 3.0 };
            Vector3 v2 = new Vector3 { x = 4.0, y = 5.0, z = 6.0 };
            
            Console.WriteLine("V3-add: " + Vector3.Add(v1, v2));
            Console.WriteLine("V3-mul: " + Vector3.Mul(2.0, v1));

            // 1a,b
            Vector3<double>.FieldAdd = DoubleAdd;
            Vector3<double>.FieldMul = DoubleMul;

            Vector3<double> t1 = new Vector3<double> { x = 1, y = 2, z = 3 };
            Vector3<double> t2 = new Vector3<double> { x = 4, y = 5, z = 6 };

            Console.WriteLine("V3d-add: " + Vector3<double>.Add(t1, t2));
            Console.WriteLine("V3d-mul: " + Vector3<double>.Mul(2.0, t1));

            // 1c
            Vector3<double>.FieldAdd = (d1, d2) => d1 + d2; //lambda
            Vector3<double>.FieldMul = delegate(double d1, double d2) { return d1*d2; }; //explicit

            Console.WriteLine("V3d-add-lambda: " + Vector3<double>.Add(t1, t2));
            Console.WriteLine("V3d-mul-explicit: " + Vector3<double>.Mul(2.0, t1));

            // 1d
            Vector3<Complex>.FieldAdd = (c1, c2) => c1 + c2;
            Vector3<Complex>.FieldMul = (c1, c2) => c1*c2;
        }
    }

    class Vector3
    {
        public double x, y, z;
        
        public static Vector3 Add(Vector3 v1, Vector3 v2)
        { 
            return new Vector3()
            {
                x = v1.x + v2.x,
                y = v1.y + v2.y,
                z = v1.z + v2.z
            };
        }
        public static Vector3 Mul(double scalar, Vector3 v2)
        {
            return new Vector3()
            {
                x = scalar * v2.x,
                y = scalar * v2.y,
                z = scalar * v2.z
            };
        }

        public override string ToString()
        {
            return "(" + x + "," + y + "," + z + ")";
        }
    }
    public class Vector3<T>
    {
        public T x, y, z;

        public static Func<T, T, T> FieldAdd { get; set; }
        public static Func<T, T, T> FieldMul { get; set; }

        public static Vector3<T> Add(Vector3<T> v1, Vector3<T> v2)
        {
            return new Vector3<T>()
            {
                x = FieldAdd(v1.x, v2.x),
                y = FieldAdd(v1.y, v2.y),
                z = FieldAdd(v1.z, v2.z)
            };
        }
        public static Vector3<T> Mul(T scalar, Vector3<T> v2)
        {
            return new Vector3<T>()
            {
                x = FieldMul(scalar, v2.x),
                y = FieldMul(scalar, v2.y),
                z = FieldMul(scalar, v2.z)
            };
        }

        public override string ToString()
        {
            return "(" + x + "," + y + "," + z + ")";
        }
    }

    public class Complex
    {
        public double r;
        public double i;

        public override string ToString()
        {
            return r + "+" + i + "i";
        }

        public static Complex operator +(Complex c1, Complex c2)
        {
            return new Complex()
            {
                r = c1.r + c2.r,
                i = c1.i + c2.i
            };
        }

        public static Complex operator *(Complex c1, Complex c2)
        {
            return new Complex()
            {
                r = c1.r * c2.r,
                i = c1.i * c2.i
            };
        }
    }
}
