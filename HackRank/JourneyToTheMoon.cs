using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    partial class Program
    {
        /// <summary>
        /// https://www.hackerrank.com/challenges/journey-to-the-moon
        /// </summary>
        private static void JourneyToTheMoon()
        {
            /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */
            string input = Console.ReadLine();
            int n = Convert.ToInt32(input.Split(' ')[0]);
            int i = Convert.ToInt32(input.Split(' ')[1]);
            List<List<int>> Ars = new List<List<int>>();
            for (int a = 0; a < i; a++)
            {
                input = Console.ReadLine();
                int a0 = Convert.ToInt32(input.Split(' ')[0]);
                int a1 = Convert.ToInt32(input.Split(' ')[1]);
                bool found = false;
                foreach (var b in Ars)
                {
                    if (b.Contains(a0))
                    {
                        b.AddAfter(b.Find(a0), a1);
                        found = true;
                        continue;
                    }
                    if (found && b.Contains(a1)) { b.Add(a0); found = true; break; }
                }
                if (!found)
                {
                    Ars.Add(new List<int>() { a0, a1 });
                }
            }
            int result = 0;
            List<int> countries = new List<int>();
            foreach (var ar in Ars)
            {
                countries.ForEach(c => result += ar.Count * c);
                countries.Add(ar.Count);
            }

            Console.WriteLine(result);
        }
    }
}
