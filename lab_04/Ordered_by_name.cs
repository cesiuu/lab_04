using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_04
{
    public class Ordered_by_name : File
    {
        public static void Print()
        {
            Console.WriteLine("   Ordered by name:");
            Console.WriteLine(String.Format("{0,-40}{1,-15}{2,-50}", " ", "[size]", "[path]"));
            List<File> Filesordered = File.Files.OrderBy(file => file.Name).ToList();
            foreach (File f in Filesordered)
            {
                Console.WriteLine(String.Format("{0,-8}{1,-33}{2,-15}{3,-50}", " ", f.Name, f.Size + " KB", f.Path));
            }
            Console.WriteLine();
        }
    }
}
