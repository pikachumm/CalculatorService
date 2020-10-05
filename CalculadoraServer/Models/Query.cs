using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CalculadoraServer.Models
{
	public class QueryRequest
	{
		public String Id { get; set; }
	}
	public class QueryRespond
	{
		public List<Operatione>  Operations{ get; set; }
	}
}