﻿using System;
using System.Diagnostics;

namespace Aheui__
{
    class Program
    {
        static void Main(string[] args)
        {
            BigIntAheui a = new BigIntAheui(@"삶은밥과야근밥샤주세양♡밥사밥사밥사밥사밥사땅땅땅빵☆따밦내발따밦다빵맣밥밥밥내놔밥줘밥밥밥밗땅땅땅박밝땅땅딻타밟타맣밦밣따박타맣밦밣따박타맣밦밣따박타맣박빵빵빵빵따따따따맣");
            a.OutputReleased += (o) => Console.Write(o);
            a.RunAll();
            Console.ReadLine();
        }
    }
}
