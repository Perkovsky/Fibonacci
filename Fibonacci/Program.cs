namespace FibonacciAlgorithm
{
	class Program
    {
		static void Main(string[] args)
        {
			var fibonacci = new Fibonacci(40);
			System.Console.WriteLine(fibonacci.CalculateUsingCycleMath());
		}
    }
}
