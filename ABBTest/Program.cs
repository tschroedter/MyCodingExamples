﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABBTest
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 42;
            int y = 12;
            int w;
            object o;
            o = x;
            w = y * (int)o;
            Console.WriteLine(w);

            Console.ReadLine();
        }
    }
}
