using System;

namespace CalculadoraServer.Models
{
	public class AddRequest
	{
		public int[] Addens { get; set; }
	}
	public class AddRespond
	{
		public int Sum { get; set; }
	}
}
