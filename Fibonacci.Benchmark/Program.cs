using BenchmarkDotNet.Running;

namespace FibonacciBenchmark
{
	class Program
	{
		static void Main(string[] args)
		{
			//NOTE:
			// 1. Use Release mode
			// 2. Press CTRL + F5

			BenchmarkRunner.Run<FibonacciBenchmark>();
		}
	}
}
