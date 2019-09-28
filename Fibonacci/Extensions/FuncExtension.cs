using System;
using System.Collections.Generic;

namespace Fibonacci.Extensions
{
	public static class FuncExtension
	{
		public static Func<T, R> Memoize<T, R>(this Func<T, R> func)
		{
			var cache = new Dictionary<T, R>();
			R result = default(R);
			return x => cache.TryGetValue(x, out result) ? result : cache[x] = func(x);
		}
	}
}
