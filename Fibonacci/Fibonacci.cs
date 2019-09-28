using System;
using System.Text;
using Fibonacci.Extensions;

namespace Fibonacci
{
	public class Fibonacci
	{
		private readonly ulong _num;

		public Fibonacci(ulong num) => _num = num;

		public string CalculateUsingDelegate()
		{
			var result = new StringBuilder();

			Func<ulong, ulong> fib = null;
			fib = x => x > 1 ? fib(x - 1) + fib(x - 2) : x;

			for (ulong i = 0; i < _num; i++)
				result.Append($"{fib(i)} ");

			return result.ToString();
		}

		public string CalculateUsingDelegateWithCache()
		{
			var result = new StringBuilder();

			Func<ulong, ulong> fib = null;
			fib = x => x > 1 ? fib(x - 1) + fib(x - 2) : x;
			fib = fib.Memoize();

			for (ulong i = 0; i < _num; i++)
				result.Append($"{fib(i)} ");

			return result.ToString();
		}

		public string CalculateUsingLocalFunction()
		{
			var result = new StringBuilder();

			ulong Fib(ulong x) => x > 1 ? Fib(x - 1) + Fib(x - 2) : x;

			for (ulong i = 0; i < _num; i++)
				result.Append($"{Fib(i)} ");

			return result.ToString();
		}

		private ulong Fib(ulong x) => x > 1 ? Fib(x - 1) + Fib(x - 2) : x;

		public string CalculateUsingTraditionalRecursion()
		{
			var result = new StringBuilder();

			for (ulong i = 0; i < _num; i++)
				result.Append($"{Fib(i)} ");

			return result.ToString();
		}

		public string CalculateUsingCycle()
		{
			var result = new StringBuilder();

			for (ulong i = 0, f1 = 0, f2 = 0; i < _num; i++)
			{
				ulong f = i > 1 ? f1 + f2 : i;
				f2 = f1;
				f1 = f;
				result.Append($"{f} ");
			}

			return result.ToString();
		}
	}
}
