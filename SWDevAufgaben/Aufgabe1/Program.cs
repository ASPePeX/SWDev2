using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aufgabe1
{
    class Program
    {
        public struct Foo
        {
            public int a;
        }
        public class Bar
        {
            public int b;
        }
        static void TakeFoo(Foo f)
        {
            f.a = 12;
        }
        static void TakeFoo(ref Foo f)
        {
            f.a = 12;
        }
        static void TakeBar(Bar b)
        {
            b.b = 12;
        }

        private static void DoSomething()
        {
            var foo = new Foo() { a = 3 };
            var bar = new Bar() { b = 3 };
//            TakeFoo(foo);
            TakeFoo(ref foo);
            TakeBar(bar);

            Console.WriteLine(foo.a);
            Console.WriteLine(bar.b);

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

