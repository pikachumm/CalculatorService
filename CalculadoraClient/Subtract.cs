using System;


namespace CalculadoraClient.Models
{
	public class SubtractRequest
	{
		public int Minuend { get; set; }
		public int Subtrahend { get; set; }
	}
	public class SubtractRespond
	{
		public int Difference { get; set; }
	}
}
