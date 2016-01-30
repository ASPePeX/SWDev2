using System;
using System.Collections.Generic;

namespace Aufgabe2
{
    class Program
    {
        static void Main(string[] args)
        {
            var root = new Group() {Name = "GroupParent"};

            root.Children.Add(new Group() { Name = "GroupChild1" });
            root.Children[0].Children.Add(new Label() { Name = "Label1" });
            root.Children[0].Children.Add(new TextInput() { Name = "TextInput1" });
            root.Children[0].Children.Add(new Label() { Name = "Label2" });
            root.Children[0].Children.Add(new TextInput() { Name = "TextInput2" });
            root.Children.Add(new Group() { Name = "GroupChild2" });
            root.Children[1].Children.Add(new Label() { Name = "Label3" });
            root.Children[1].Children.Add(new CheckBox() { Name = "CheckBox3" });
            root.Children[1].Children.Add(new Image() { Name = "Image1" });

            var visitor = new XMLWriterVisitor();

            root.Accept(visitor);
        }
    }

    class Group : UIElement
    {
    }

    class Label : UIElement
    {
    }
    class TextInput : UIElement
    {
    }
    class CheckBox : UIElement
    {
    }
    class Image : UIElement
    {
    }

    class XMLWriterVisitor : IVisitor
    {
        public void Visit(UIElement visitable)
        {
            Console.WriteLine("<" + visitable.GetType() + " Name='" + visitable.Name + "'> /");
        }
    }

    abstract class UIElement : IVisitable
    {
        public string Name { get; set; }
        public List<UIElement> Children { get; set; }

        public UIElement()
        {
            Children = new List<UIElement>();
        }

        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
            foreach (var child in Children)
            {
                child.Accept(visitor);
            }
        }
    }

    //interface for Visitors
    interface IVisitor
    {
        void Visit(UIElement visitable);
    }

    //interface for Visitables
    interface IVisitable
    {
        void Accept(IVisitor visitor);
    }
}
