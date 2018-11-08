using System;
using System.Numerics;

namespace SandBox.CodewarsKatas.WIP
{
    //https://www.codewars.com/kata/the-millionth-fibonacci-kata
    class MillionthFibonacciKata
    {
        public static BigInteger Fib(int n)
        {
            if(n < 0)
                throw new Exception("Sequence position can not be negative.");

            return FibHandler(n);
        }

        //Slow, handles only like first 40 
        public static BigInteger FibHandler(int n)
        {
            switch (n)
            {
                case 0:
                    return BigInteger.Zero;
                case 1:
                case 2:
                    return BigInteger.One;
                default:
                    return Fib(n - 2) + Fib(n - 1);
            }
        }
    }
}
