using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CalculadoraClient.Models
{

	public class DivRequest
	{
		public int Dividend { get; set; }

		public int Divisor { get; set; }
	}
	public class DivRespond
	{
		public int Quotient { get; set; }
		public int Remainder { get; set; }
	}
}