using System;
using System.Collections.Generic;

namespace Fibonacci
{
    public static class Memoizers
    {
        public static Func<T, R> Memoize<T, R>(this Func<T, R> func)
        {
            var cache = new Dictionary<T, R>();
            R result = default(R);
            return x => cache.TryGetValue(x, out result) ? result : cache[x] = func(x);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Func<ulong, ulong> fib = null;
            fib = x => x > 1 ? fib(x - 1) + fib(x - 2) : x;
            fib = fib.Memoize();

            //ulong Fib(ulong x) => x > 1 ? Fib(x - 1) + Fib(x - 2) : x;

            for (ulong i = 0; i < 50; i++)
            {
                Console.Write($"{fib(i)} ");
            }
            Console.WriteLine("Completed!");

            Console.ReadKey();

        }
    }
}
