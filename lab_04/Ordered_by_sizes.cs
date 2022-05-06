using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_04
{
    public class Ordered_by_sizes : File
    {
        public static void Print()
        {
            Console.WriteLine("   Ordered by size (from biggest):");
            Console.WriteLine(String.Format("{0,-40}{1,-15}", " ", "[size]"));
            List<File> Filesordered = File.Files.OrderByDescending(file => file.Size).ToList();
            foreach (File f in Filesordered)
            {
                Console.WriteLine(String.Format("{0,-8}{1,-33}{2,-15}", " ", f.Name, f.Size + " KB"));
            }
            Console.WriteLine();
        }
    }
}
