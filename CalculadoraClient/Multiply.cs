using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CalculadoraClient.Models
{
	public class MultiplyRequest
	{
		public int[] Factors { get; set; }
	}
	public class MultiplyRespond
	{
		public int Product { get; set; }

	}
}
