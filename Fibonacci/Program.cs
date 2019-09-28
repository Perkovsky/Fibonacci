using System;
using System.Diagnostics;

namespace Fibonacci
{
    class Program
    {
		static void TimedAction(string name, Action action)
		{
			var sw = new Stopwatch();
			sw.Start();
			action();
			sw.Stop();
			Console.WriteLine($"{name}: {sw.Elapsed}");
		}

		static void Main(string[] args)
        {
			ulong num = 40;
			var f = new Fibonacci(num);
			Console.WriteLine($"Number: {num}");
			Console.WriteLine(new string('-', 10));

			//Console.WriteLine(f.CalculateUsingCycle() + Environment.NewLine);
			//Console.WriteLine(f.CalculateUsingLocalFunction() + Environment.NewLine);
			//Console.WriteLine(f.CalculateUsingTraditionalRecursion() + Environment.NewLine);
			//Console.WriteLine(f.CalculateUsingDelegate() + Environment.NewLine);
			//Console.WriteLine(f.CalculateUsingDelegateWithCache() + Environment.NewLine);
			//Console.WriteLine(new string('-', 10));

			TimedAction("Calculate using cycle\t\t\t", () => f.CalculateUsingCycle());
			TimedAction("Calculate using local function\t\t", () => f.CalculateUsingLocalFunction());
			TimedAction("Calculate using traditional recursion\t", () => f.CalculateUsingTraditionalRecursion());
			TimedAction("Calculate using delegate\t\t", () => f.CalculateUsingDelegate());
			TimedAction("Calculate using delegate (with cache)\t", () => f.CalculateUsingDelegateWithCache());

			Console.ReadKey();
        }
    }
}
