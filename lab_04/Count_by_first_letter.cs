using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_04
{
    public class Count_by_first_letter
    {
        static List<string> chars = new List<string> { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "r", "t", "u", "w", "x", "y", "z" };
        public static void Print()
        {
            Console.WriteLine("   Counts by first letter:");
            int a = 0;
            //używam IDictionary<string, int> żeby do każdej litery mieć przypisaną ilość słów zaczynających się na tę literę
            IDictionary<string, int> dictionary = new Dictionary<string, int>();
            for (int i = 0; i < chars.Count; i++)
                {
                    foreach (File f in File.Files)
                    {
                        if (f.Firstletter == chars[i])
                            a++;
                    }
                dictionary.Add(chars[i], a);
                a = 0;
            }
            Console.Write(String.Format("{0,-8}", " "));
            foreach (KeyValuePair<string, int> pair in dictionary)
                Console.Write(pair.Key + " ");
            Console.WriteLine();
            Console.Write(String.Format("{0,-8}", " "));
            foreach (KeyValuePair<string, int> pair in dictionary)
                Console.Write(pair.Value + " ");
            Console.WriteLine("\n");
        }
    }
}
