using System;

namespace DependencyInjection
{
    class Program
    {
        static void Main(string[] args)
        {
            Depending depending = new Depending();

            //depending.SetDependency(new Dep2());
            depending.Dep = new Dep1();

            depending.DoSomething();
        }
    }

    class Depending
    {
        //Dependency Injection by Property
        public IDependency Dep { get; set; } = null;

        public Depending()
        {
        }

        //Dependency Injection by Constructor
        public Depending(IDependency dependency)
        {
            this.Dep = dependency;
        }

        //Dependency Injection by Method
        public void SetDependency(IDependency dependency)
        {
            this.Dep = dependency;
        }

        public void DoSomething()
        {
            if (Dep == null)
            {
                Console.WriteLine("No dependency injected");
            }
            else
            {
                Dep.Output();
            }
        }
    }

    interface IDependency
    {
        void Output();
    }

    class Dep1 : IDependency
    {
        public void Output()
        {
            Console.WriteLine("I'm Dependecy 1: " + this.GetType());
        }
    }

    class Dep2 : IDependency
    {
        public void Output()
        {
            Console.WriteLine("I'm Dependecy 2: " + this.GetType());
        }
    }
}
