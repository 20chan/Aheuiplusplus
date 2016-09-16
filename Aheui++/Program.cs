using System;
using System.Diagnostics;

namespace Aheui__
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch s = new Stopwatch();
            s.Start();
            BigIntAheui a = new BigIntAheui(@"바싹반박나싼순
뿌멓떠벌번멍뻐
쌀삭쌀살다순옭
어어선썬설썩옭");
            a.OutputReleased += (o) => Console.Write(o);
            a.RunAll();
            Console.WriteLine(s.ElapsedMilliseconds);
            Console.ReadLine();
        }
    }
}
