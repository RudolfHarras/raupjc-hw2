using System;
using System.Threading.Tasks;

namespace Assignment6_7 
{
	class Assignment67 
	{

		private static async Task<int> FactorialDigitSum(int n)
		{
			int fact = await Task.Run(() => Factorial(n));
			int result = 0;

			while (fact > 0)
			{
				result += fact % 10;
				fact /= 10;
			}
			return result;
		}


		private static int Factorial(int number) 
		{
			int result = 1;
			for (int i = 1; i <= number; i++) {
				result = result * i;
			}
			return result;
		}

		private static async void LetsSayUserClickedAButtonOnGuiMethod() 
		{
			var result = await GetTheMagicNumber();
			Console.WriteLine(result);
		}

		private static async Task<int> GetTheMagicNumber() 
		{
			return await Task.Run(() => IKnowIGuyWhoKnowsAGuy());
		}

		private static async Task<int> IKnowIGuyWhoKnowsAGuy() 
		{
			int ret1 = await Task.Run(() => IKnowWhoKnowsThis(10));
			int ret2 = await Task.Run(() => IKnowWhoKnowsThis(5));
			return ret1 + ret2;
		}

		private static async Task<int> IKnowWhoKnowsThis(int n) {
			return await FactorialDigitSum(n);
		}


		static void Main(string[] args)
		{
		    var t = Task.Run(() => LetsSayUserClickedAButtonOnGuiMethod());
		    Console.Read();
		}

	}
}