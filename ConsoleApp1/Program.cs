﻿using Algorithm;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.InteropServices;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //var result = new EggAndFloor().CountMinSetp(2, 100);
            var result = new BinaryCount().Calc(8);  //8

            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
