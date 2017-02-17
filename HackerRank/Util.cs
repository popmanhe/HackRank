using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank
{
    class Util
    {
        public static string ReadLine(string input, int lineNumber)
        {

            System.IO.StreamReader sr = new System.IO.StreamReader(input);
            int i = 0;
            while (i < lineNumber)
            {
                sr.ReadLine();
                i++;
            }
            return sr.ReadLine();
        }
    }
}
