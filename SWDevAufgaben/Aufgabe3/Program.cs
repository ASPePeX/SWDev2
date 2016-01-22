using System;

namespace Aufgabe3
{
    class Program
    {
        public static UInt64 Fibonacci(UInt64 n)
        {
            UInt64 a = 0;
            UInt64 b = 1;
            // In N steps compute Fibonacci sequence iteratively.
            for (UInt64 i = 0; i < n; i++)
            {
                UInt64 temp = a;
                a = b;
                b = temp + b;
            }
            return a;
        }

        static void Main()
        {
            for (UInt64 i = 0; i < 100; i++)
            {
                Console.WriteLine(Fibonacci(i));
            }
        }
    }
}
