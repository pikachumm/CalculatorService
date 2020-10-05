using CalculadoraClient;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Text;
using CalculadoraClient.Models;
using RestSharp;
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
