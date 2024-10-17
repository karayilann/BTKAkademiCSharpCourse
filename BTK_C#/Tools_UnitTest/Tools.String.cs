using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools
{
    public class Program
    {
        static void Main(string[] args)
        {
        }
    }


    public static class StringHelper
    {
        public static string Clean(string input)
        {
            if (input == null)
            {
                return null;
            }

            return input.Trim().Replace(" ", "");
        }
    }


}
