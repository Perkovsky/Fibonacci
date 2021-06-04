using BenchmarkDotNet.Attributes;
using FibonacciAlgorithm;

namespace FibonacciBenchmark
{
	[MemoryDiagnoser]
	[RankColumn]
    public class FibonacciBenchmark
    {
        private readonly Fibonacci _fibonacci = new Fibonacci(40);

		[Benchmark]
		public void CalculateUsingDelegate() => _fibonacci.CalculateUsingDelegate();

		[Benchmark]
		public void CalculateUsingDelegateWithMemoization() => _fibonacci.CalculateUsingDelegateWithMemoization();

		[Benchmark]
		public void CalculateUsingLocalFunction() => _fibonacci.CalculateUsingLocalFunction();

		[Benchmark]
		public void CalculateUsingTraditionalRecursion() => _fibonacci.CalculateUsingTraditionalRecursion();

		[Benchmark]
		public void CalculateUsingCycle() => _fibonacci.CalculateUsingCycle();
	}
}
