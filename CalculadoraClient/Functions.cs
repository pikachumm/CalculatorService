using System;


using RestSharp;
using CalculadoraClient.Models;

namespace CalculadoraClient.Functions
{
	public class Functions
	{
		public static int ReadInt(string text)
		{
			bool exit = false;
			int number = 0;
			do
			{
				try
				{

					Console.WriteLine(text);
					Console.Write(">>");
					number = int.Parse(Console.ReadLine());
					exit = true;
				}
				catch (System.FormatException)
				{
					Console.WriteLine("Error de formato");
					exit = false;

				}

			} while (exit == false);
			return number;
		}


		public static int[] ReadIntArray(string text)
		{
			int many = 0;
			int[] array;
			do
			{
					many = ReadInt("Lenght");
				} while (many < 1);
				array = new int[many];
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = ReadInt("numero");
				}
			return array;
		}


		public static int AskForOperation()
		{
			int selected = ReadInt(@"
1.	Add 
2.	Substract 
3.	Multiply 
4.	Div 
5.	Square 
6.	Query 
7.	Exit");
			switch (selected)
			{
				case 1:
					AplyAdd();
					break;
				case 2:
					AplySubstract();
					break;
				case 3:
					AplyMultiply();
					break;
				case 4:
					AplyDiv();

					break;
				case 5:
					AplySquare();
					break;
				case 6:
					AplyQuery();
					break;
				case 7:
					Console.WriteLine("hasta luego :D");
					break;
				default:
					Console.WriteLine("opcion no valida");
					break;

			}
			return selected;
		}

		private static void AplyQuery()
		{
			QueryRequest query = new QueryRequest();
			Console.WriteLine("Id to search");
			query.Id = Console.ReadLine();
			var client = new RestClient("http://localhost:63115/api/Calculator/");
			var request = new RestRequest("query", Method.POST);
			request.AddJsonBody(query);
			var response = client.Execute(request);
			Console.WriteLine(response.Content);
		}



		private static void AplySquare()
		{
			string IdHeader = null;
			SquareRequest square = new SquareRequest();
			square.Number = ReadInt("Number");
			Console.WriteLine("Track id? Type yes");
			Console.Write(">>");
			string tracking = Console.ReadLine();
			if (tracking.Equals("yes"))
			{
				Console.WriteLine("Id header");
				Console.Write(">>");
				IdHeader = Console.ReadLine();
			}
			var client = new RestClient("http://localhost:63115/api/Calculator/");
			var request = new RestRequest("square", Method.POST);
			request.AddJsonBody(square);
			if (IdHeader != null && IdHeader != "")
			{
				request.AddHeader("X-Evi-Tracking-Id", IdHeader);
			}
			var response = client.Execute(request);
			Console.WriteLine(response.Content);
		}


		private static void AplyDiv()
		{
			string IdHeader = null;
			DivRequest div = new DivRequest();
			div.Dividend = ReadInt("Dividend");
			div.Divisor = ReadInt("Divisor");
			Console.WriteLine("Track id? Type yes");
			Console.Write(">>");
			string tracking = Console.ReadLine();
			if (tracking.Equals("yes"))
			{
				Console.WriteLine("Id header");
				Console.Write(">>");
				IdHeader = Console.ReadLine();
			}
			var client = new RestClient("http://localhost:63115/api/Calculator/");
			var request = new RestRequest("div", Method.POST);
			request.AddJsonBody(div);
			if (IdHeader != null && IdHeader != "")
			{
				request.AddHeader("X-Evi-Tracking-Id", IdHeader);
			}
			var response = client.Execute(request);
			Console.WriteLine(response.Content);
		}


		private static void AplyMultiply()
		{
			string IdHeader = null;
			MultiplyRequest multiply = new MultiplyRequest();
			multiply.Factors = ReadIntArray("Enter factor");
			Console.WriteLine("Track id? Type yes");
			Console.Write(">>");
			string tracking = Console.ReadLine();
			if (tracking.Equals("yes"))
			{
				Console.WriteLine("Id header");
				Console.Write(">>");
				IdHeader = Console.ReadLine();
			}

			var client = new RestClient("http://localhost:63115/api/Calculator/");
			var request = new RestRequest("multiply", Method.POST);
			request.AddJsonBody(multiply);
			if (IdHeader != null && IdHeader != "")
			{
				request.AddHeader("X-Evi-Tracking-Id", IdHeader);
			}
			var response = client.Execute(request);
			Console.WriteLine(response.Content);
		}


		private static void AplySubstract()
		{
			string IdHeader = null;
			SubtractRequest substract = new SubtractRequest();
			substract.Minuend = ReadInt("Minuend");
			substract.Subtrahend = ReadInt("Substract");
			Console.WriteLine("Track id? Type yes");
			Console.Write(">>");
			string tracking = Console.ReadLine();
			if (tracking.Equals("yes"))
			{
				Console.WriteLine("Id header");
				Console.Write(">>");
				IdHeader = Console.ReadLine();
			}
			var client = new RestClient("http://localhost:63115/api/Calculator/");
			var request = new RestRequest("substract", Method.POST);
			request.AddJsonBody(substract);
			if (IdHeader != null && IdHeader != "")
			{
				request.AddHeader("X-Evi-Tracking-Id", IdHeader);
			}
			var response = client.Execute(request);
			Console.WriteLine(response.Content);
		}


		private static void AplyAdd()
		{
			string IdHeader = null;
			AddRequest add = new AddRequest();
			add.Addens = ReadIntArray("numer to add");
			Console.WriteLine("Track id? Type yes");
			Console.Write(">>");
			string tracking = Console.ReadLine();
			if (tracking.Equals("yes"))
			{
				Console.WriteLine("Id header");
				Console.Write(">>");
				IdHeader = Console.ReadLine();
			}
			var client = new RestClient("http://localhost:63115/api/Calculator/");
			var request = new RestRequest("add", Method.POST);
			request.AddJsonBody(add);
			if (IdHeader != null && IdHeader != "")
			{
				request.AddHeader("X-Evi-Tracking-Id", IdHeader);
			}
			var response = client.Execute(request);
			Console.WriteLine(response.Content);
		}

	}
}