using CalculadoraClient.Functions;

namespace CalculadoraClient
{

}
	class Program
	{
		
		
		public static void Main(string[] args)
		{
		int option = 0;
			do
			{
				option = Functions.AskForOperation();
			} while (option != 7);
		}
	}
