using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FibonacciAlgorithm.Extensions;

namespace FibonacciAlgorithm
{
	public class Fibonacci
	{
		private static readonly double sqrt5 = Math.Sqrt(5);
		private static readonly double p1 = (1 + sqrt5) / 2;
		private static readonly double p2 = -1 * (p1 - 1);

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

		public string CalculateUsingDelegateWithMemoization()
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

		public string CalculateUsingCycleMath()
		{
			var result = new StringBuilder();
			result.Append("0 ");
			double n1 = 1.0;
			double n2 = 1.0;

			for (ulong i = 0; i < _num - 1; i++)
			{
				n1 *= p1;
				n2 *= p2;
				result.Append($"{(ulong)((n1 - n2) / sqrt5)} ");
			}

			return result.ToString();
		}

		public string CalculateUsingParallelForMath()
		{
			var result = new StringBuilder();
			result.Append("0 ");
			double n1 = 1.0;
			double n2 = 1.0;
			
			Parallel.For(0, (int)_num - 1, (x) => {
				n1 *= p1;
				n2 *= p2;
				result.Append($"{(ulong)((n1 - n2) / sqrt5)} ");
			});

			return result.ToString();
		}

		public string CalculateUsingLinq()
		{
			var result = Enumerable.Range(0, (int)_num)
				.Aggregate(new { Current = 1, Prev = 1, Result = new StringBuilder() }, (x, index) => new 
				{ 
					Current = index > 1 ? x.Prev + x.Current : index,
					Prev = x.Current,
					Result = x.Result.Append(string.Format("{0} ", index > 1 ? x.Prev + x.Current : index))
				})
				.Result;

			return result.ToString();
		}

		public string CalculateUsingParallelLinq()
		{
			var result = Enumerable.Range(0, (int)_num)
				.AsParallel()
				.Aggregate(new { Current = 1, Prev = 1, Result = new StringBuilder() }, (x, index) => new
				{
					Current = index > 1 ? x.Prev + x.Current : index,
					Prev = x.Current,
					Result = x.Result.Append(string.Format("{0} ", index > 1 ? x.Prev + x.Current : index))
				})
				.Result;

			return result.ToString();
		}
	}
}
