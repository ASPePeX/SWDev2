using System;
using System.Linq;

namespace Lambdas
{
    class Program
    {
        static void Main()
        {
            var names = new[] {"Bla", "Blub", "blabber", "doof", "nub"};

            //Filtered with an delegate function
            //var del = new Func<string, bool>(Filter);
            //var filteredNames = names.Where(del);

            // Filtered with a looong delegate
            //var filteredNames = names.Where(delegate (string item) { return item.Contains("B"); });

            // Filtered by a short lambda
            var filteredNames = names.Where(item => item.Contains("B"));


            foreach (var bla in filteredNames)
            {
                Console.WriteLine(bla);
            }
        }

        public static bool Filter(string item)
        {
            return item.Contains("B");
        }
    }
}
