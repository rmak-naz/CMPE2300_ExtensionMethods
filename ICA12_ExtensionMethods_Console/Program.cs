using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICA12_ExtensionMethods_Console
{
    class Program
    {
        static Random _rnd = new Random();
        static void Main(string[] args)
        {
            List<int> iNums = new List<int>(new int[] { 4, 12, 4, 3, 5, 6, 7, 6, 12 });
            foreach (KeyValuePair<int, int> scan in iNums.Categorize())
                Console.WriteLine(scan.Key.ToString("d3") + " x " + scan.Value.ToString("d5"));

            Console.WriteLine("------------");
            List<string> names = new List<string>(new string[] {
                "Rick", "Glenn", "Rick", "Carl", "Michonne", "Rick", "Glenn" });
            foreach (KeyValuePair<string, int> scan in names.Categorize())
                Console.WriteLine(scan.Key + " x " + scan.Value.ToString("d5"));

            Console.WriteLine("------------");
            LinkedList<char> llfloats = new LinkedList<char>();
            while (llfloats.Count < 1000)
                llfloats.AddLast((char)_rnd.Next('A', 'Z' + 1));
            foreach (KeyValuePair<char, int> scan in llfloats.Categorize())
                Console.WriteLine(scan.Key + " x " + scan.Value.ToString("d5"));

            Console.WriteLine("------------");
            string TestString = "This is the test string, do not panic!";
            foreach (KeyValuePair<char, int> scan in TestString.Categorize())
                Console.WriteLine(scan.Key + " x " + scan.Value.ToString("d5"));

            Console.WriteLine("------------");            
            Console.WriteLine("Popular() test.");
            Console.WriteLine(TestString);
            Console.WriteLine(TestString.Popular() + " is the most popular value.");

            foreach (int scan in iNums)
                Console.Write(scan + " ");
            Console.WriteLine();
            Console.WriteLine(iNums.Popular() + " is the most popular int value.");

            

            Console.WriteLine("------------");
            Console.WriteLine("Shuffle() test.");
            foreach (char scan in TestString.Shuffle(_rnd))
                Console.Write(scan);
            Console.WriteLine();

            foreach (int scan in iNums)
                Console.Write(scan + " ");
            Console.WriteLine();
            foreach (int scan in iNums.Shuffle(_rnd))
                Console.Write(scan + " ");

            Console.ReadKey();
        }
    }
}
