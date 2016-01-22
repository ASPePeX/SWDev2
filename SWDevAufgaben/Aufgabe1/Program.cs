using System;

namespace Aufgabe1
{
    class Program
    {
        public struct Foo
        {
            public int A;
        }
        public class Bar
        {
            public int B;
        }
        static void TakeFoo(Foo f)
        {
            f.A = 12;
        }
        static void TakeFoo(ref Foo f)
        {
            f.A = 12;
        }
        static void TakeBar(Bar b)
        {
            b.B = 12;
        }

        private static void DoSomething()
        {
            var foo = new Foo() { A = 3 };
            var bar = new Bar() { B = 3 };
//            TakeFoo(foo);
            TakeFoo(ref foo);
            TakeBar(bar);

            Console.WriteLine(foo.A);
            Console.WriteLine(bar.B);

            // Ohne ref:
            // foo.a = 3
            // bar.b = 12

            // Mit ref:
            // foo.a = 12
            // bar.b = 12

        }

        static void Main(string[] args)
        {
            DoSomething();
        }
    }
}

