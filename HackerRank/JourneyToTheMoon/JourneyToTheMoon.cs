using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank
{
    class JourneyToTheMoon
    {
        /// <summary>
        /// https://www.hackerrank.com/challenges/journey-to-the-moon
        /// </summary>
        public static void Run()
        {
            /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */
            string input = @"..\..\JourneyToTheMoon\input_11.txt";
            string line = Util.ReadLine(input, 0);
            int n = Convert.ToInt32(line.Split(' ')[0]);
            int i = Convert.ToInt32(line.Split(' ')[1]) + 1;
            List<List<int>> Ars = new List<List<int>>();
            List<int> foundList = null;
            //Add all numbers in case some numbers are not in the input list
            List<int> all = new List<int>();
            for (int a = 0; a < n; a++)
            {
                all.Add(a);
            }
            for (int a = 1; a < i; a++)
            {
                line = Util.ReadLine(input, a);
                int a0 = Convert.ToInt32(line.Split(' ')[0]);
                int a1 = Convert.ToInt32(line.Split(' ')[1]);
                if (a0 >= 0 && a0 < n && a1 >= 0 && a1 < n)
                {
                    foundList = null;
                    foreach (var b in Ars)
                    {
                        if (b.Count == 0) continue;

                        if (b.Contains(a0))
                        {
                            if (foundList != null)
                            {
                                foundList.Remove(a0);
                                foundList.AddRange(b);
                                b.Clear();
                            }
                            else
                            {
                                if (!b.Contains(a1)) b.Add(a1);
                                all.Remove(a1);
                                foundList = b;
                            }
                            continue;
                        }
                        if (b.Contains(a1))
                        {
                            if (foundList != null)
                            {
                                foundList.Remove(a1);
                                foundList.AddRange(b);
                                b.Clear();
                            }
                            else
                            {
                                if (!b.Contains(a0)) b.Add(a0);
                                all.Remove(a0);
                                foundList = b;
                            }
                        }
                    }
                    if (foundList == null)
                    {
                        Ars.Add(new List<int>() { a0, a1 });
                        all.Remove(a0);
                        all.Remove(a1);
                    }
                }
            }
            Int64 result = 0;
            List<int> countries = new List<int>();

            //pattern:  (a*b) + (a+b)*c + (a+b+c)*d
            foreach (var ar in Ars)
            {
                if (ar.Count > 0)
                {
                    countries.ForEach(c => result += ar.Count * c);
                    countries.Add(ar.Count);
                }
            }
            //There are singleton groups
            if (all.Count > 0)
            {
                int total = 0;
                countries.ForEach(c => total += c);
                //arithmetic progression (1+n)*n/2
                result += (Int64)(total + total + all.Count - 1) * all.Count / 2;
            }
            Console.WriteLine(result);
        }
    }
}
