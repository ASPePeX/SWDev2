using System;
using System.Collections;

namespace Enumerator
{
    internal class Program
    {
        private static void Main()
        {
            var bub = new StringArray(5);

            bub.InsertAt(1, "bla");
            bub.InsertAt(3, "blab");
            bub.InsertAt(4, "blub");

            foreach (var b in bub)
            {
                Console.WriteLine(b);
            }
        }
    }

    internal class StringArray : IEnumerable
    {
        private readonly string[] _stringArray;

        public StringArray(int num)
        {
            _stringArray = new string[num];
        }

        public void InsertAt(int index, string text)
        {
            if (index < _stringArray.Length)
                _stringArray[index] = text;
        }

        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < _stringArray.Length; i++)
            {
                yield return _stringArray[i];
            }
        }
    }
}
