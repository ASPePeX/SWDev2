using System;
using System.Collections.Generic;

namespace VisitorPattern
{
    class Program
    {
        static void Main()
        {
            //Create VisitableStructure and attach Visitable elements
            VisitableStructure o = new VisitableStructure();
            o.Attach(new VisitableA());
            o.Attach(new VisitableB());

            //Create Visitors
            Visitor1 v1 = new Visitor1();
            Visitor2 v2 = new Visitor2();

            //Let Visitors visit the VisitableStructure ... visit!
            o.Accept(v1);
            o.Accept(v2);
        }

        //interface for Visitors
        interface IVisitor
        {
            void Visit(IVisitable visitable);
        }

        //interface for Visitables
        interface IVisitable
        {
            void Accept(IVisitor visitor);
        }


        //Visitor 1
        class Visitor1 : IVisitor
        {
            public void Visit(IVisitable visitable)
            {
                Console.WriteLine("{0} visited by {1}", visitable.GetType().Name, this.GetType().Name);
            }
        }

        //Visitor 2
        class Visitor2 : IVisitor
        {
            public void Visit(IVisitable visitable)
            {
                Console.WriteLine("{0} visited by {1}", visitable.GetType().Name, this.GetType().Name);
            }
        }

        //Visitable A
        class VisitableA : IVisitable
        {
            public void Accept(IVisitor visitor)
            {
                visitor.Visit(this);
            }
        }

        //Visitable B
        class VisitableB : IVisitable
        {
            public void Accept(IVisitor visitor)
            {
                visitor.Visit(this);
            }
        }

        class VisitableStructure
        {
            private List<IVisitable> _elements = new List<IVisitable>();

            public void Attach(IVisitable visitable)
            {
                _elements.Add(visitable);
            }

            public void Detach(IVisitable visitable)
            {
                _elements.Remove(visitable);
            }

            public void Accept(IVisitor visitor)
            {
                foreach (IVisitable element in _elements)
                {
                    element.Accept(visitor);
                }
            }
        }
    }
}
