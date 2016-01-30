using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aufgabe3d
{
    class Program
    {
        static void Main(string[] args)
        {
            var lab = new Label() { Name= "blub"};
            lab.WriteToFile();
        }
    }


    public class UIElement
    {
        public string Name { get; set; }

        public virtual void WriteToFile()
        {
            Console.WriteLine("AAAAAAAAAAAAAAAAAAAA");
            Console.WriteLine("AAAAAAAAAAAAAAAAAAAA");
        }
    }

    public class Group : UIElement
    {
        private List<UIElement> _children;
        public IEnumerable<UIElement> Children { get { return _children; } }
        public void WriteToFile()
        {
            //file.WriteLine("<Group Name='" + Name + "'>");
            foreach (var child in Children)
            {
                Console.WriteLine(child.Name);
            }
            //file.WriteLine("</Group>");
        }
    }

    public class Label : UIElement
    {
        public void WriteToFile()
        {
            Console.WriteLine(Name);
        }
    }

    public class TextInput : UIElement
    {
        public void WriteToFile()
        {
            //file.WriteLine("<TextInput Name='" + Name + "'/>");
        }
    }
}
