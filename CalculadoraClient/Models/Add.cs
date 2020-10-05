using System;
using System.Collections.Generic;
using System.Linq;


namespace CalculadoraClient.Models
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
