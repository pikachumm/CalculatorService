using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using CalculadoraServer.Models;
using System;
using NLog;
using System.Net.Http;
using System.Web;
using System.Linq;

namespace CalculadoraServer.Controllers
{
	public class CalculatorController : ApiController
	{

		public static Dictionary<string, List<Operatione>> journals = new Dictionary<string, List<Operatione>>();
		private static Logger log = LogManager.GetCurrentClassLogger();
		//POST: api/Calculator
		[HttpPost]
		[ActionName("add")]
		public AddRespond AddPost(AddRequest values)
		{
			log.Trace("this is the service -> Add");
			var hasTrackingHeader = Request.Headers.Contains("X-Evi-Tracking-Id");
			var id = hasTrackingHeader ? Request.Headers.GetValues("X-Evi-Tracking-Id").FirstOrDefault() : "";
			int operation = 0;
			AddRespond respond = new AddRespond();
			if (values == null)
			{
				log.Error(HttpStatusCode.BadRequest);
				throw new ArgumentNullException();
			}else {
			try {
					
					foreach (int num in values.Addens)
						{
							operation += num;
						}
					if (id != null || id == "")
					{
						if (!journals.ContainsKey(id))
						{
							List<Operatione> Ops = new List<Operatione>();
							Operatione op = new Operatione();
							op.Operation = "add";
							op.Calculation = string.Join("+", values.Addens) + " = " + operation;
							op.Date = DateTime.Now.ToString("u");
							Ops.Add(op);
							journals[id] = Ops;

						}else {
							var Ops = journals[id];
							Operatione op = new Operatione();
							op.Operation = "add";
							op.Calculation = string.Join("+", values.Addens) + " = " + operation;
							op.Date = DateTime.Now.ToString("u");
							Ops.Add(op);
							journals[id] = Ops;
						}
					}

					respond.Sum = operation;
				log.Info(HttpStatusCode.OK);
			}
			catch(Exception e) {
				log.Error(HttpStatusCode.InternalServerError);
				log.Error("Error in the controller Add " + e);
				throw new Exception();
			}
			}
			return respond;

		}


		[HttpPost]
		[ActionName("substract")]
		public SubtractRespond SubstractPost(SubtractRequest values)
		{
			log.Trace("this is the service -> substract");
			var hasTrackingHeader = Request.Headers.Contains("X-Evi-Tracking-Id");
			var id = hasTrackingHeader ? Request.Headers.GetValues("X-Evi-Tracking-Id").FirstOrDefault() : "";
			SubtractRespond respond = new SubtractRespond();
			
			if (values == null)
			{
				log.Error(HttpStatusCode.BadRequest);
				throw new ArgumentNullException();
			}else {

				try
				{
					respond.Difference = values.Minuend - values.Subtrahend;
					if (id != null || id == "")
					{
						if (!journals.ContainsKey(id))
						{
							List<Operatione> Ops = new List<Operatione>();
							Operatione op = new Operatione();
							op.Operation = "substract";
							op.Calculation = values.Minuend + " - " + values.Subtrahend + " = " + respond.Difference;
							op.Date = DateTime.Now.ToString("u");
							Ops.Add(op);
							journals[id] = Ops;

						}
						else
						{
							var Ops = journals[id];
							Operatione op = new Operatione();
							op.Operation = "substract";
							op.Calculation = values.Minuend + " - " + values.Subtrahend + " = " + respond.Difference;
							op.Date = DateTime.Now.ToString("u");
							Ops.Add(op);
							journals[id] = Ops;
						}
						
					}
					log.Info(HttpStatusCode.OK);
				}

				catch (Exception e)
				{
					log.Error(HttpStatusCode.InternalServerError);
					log.Error("Error in the controller substract " + e);
					throw new Exception();
				}
			}
			return respond;

		}
		[HttpPost]
		[ActionName("multiply")]
		public MultiplyRespond MultiplyPost(MultiplyRequest values)
		{
			log.Trace("this is the service -> multiply");
			var hasTrackingHeader = Request.Headers.Contains("X-Evi-Tracking-Id");
			var id = hasTrackingHeader ? Request.Headers.GetValues("X-Evi-Tracking-Id").FirstOrDefault() : "";
			int operation = 1;
			MultiplyRespond respond = new MultiplyRespond();
			if (values == null)
			{
				log.Error(HttpStatusCode.BadRequest);
				throw new ArgumentNullException();
			}else {

			try
			{
				foreach (int num in values.Factors)
				{
					operation = operation * num;
				}
					if (id != null || id == "")
					{
						if (!journals.ContainsKey(id))
						{
							List<Operatione> Ops = new List<Operatione>();
							Operatione op = new Operatione();
							op.Operation = "multiply";
							op.Calculation = string.Join("*", values.Factors) + " = " + operation;
							op.Date = DateTime.Now.ToString("u");
							Ops.Add(op);
							journals[id] = Ops;

						}
						else
						{
							var Ops = journals[id];
							Operatione op = new Operatione();
							op.Operation = "multiply";
							op.Calculation = string.Join("*", values.Factors) + " = " + operation;
							op.Date = DateTime.Now.ToString("u");
							Ops.Add(op);
							journals[id] = Ops;
						}
					}
					respond.Product = operation;
				log.Info(HttpStatusCode.OK);
			}
			catch (Exception e)
			{
				log.Error(HttpStatusCode.InternalServerError);
				log.Error("Error in the controller multiply " + e);
				throw new Exception();
			}
			}
			return respond;

		}
		[HttpPost]
		[ActionName("div")]
		public DivRespond DivPost(DivRequest values) {
			log.Trace("this is the service -> div");
			var hasTrackingHeader = Request.Headers.Contains("X-Evi-Tracking-Id");
			var id = hasTrackingHeader ? Request.Headers.GetValues("X-Evi-Tracking-Id").FirstOrDefault() : "";
			DivRespond respond = new DivRespond();
			if (values == null)
			{
				log.Error(HttpStatusCode.BadRequest);
				throw new ArgumentNullException();
			}
			else
			{
				try
				{
					var result = values.Dividend / values.Divisor;
					var result1 = values.Dividend % values.Divisor;
					if (id != null || id == "")
					{
						if (!journals.ContainsKey(id))
						{
							List<Operatione> Ops = new List<Operatione>();
							Operatione op = new Operatione();
							op.Operation = "div";
							op.Calculation = values.Dividend + " / " + values.Divisor + " = " + result + " Remainer " +  result1;
							op.Date = DateTime.Now.ToString("u");
							Ops.Add(op);
							journals[id] = Ops;

						}
						else
						{
							var Ops = journals[id];
							Operatione op = new Operatione();
							op.Operation = "div";
							op.Calculation = values.Dividend + " / " + values.Divisor + " = " + result + " Remainer " + result1;
							op.Date = DateTime.Now.ToString("u");
							Ops.Add(op);
							journals[id] = Ops;
						}

					}
					respond.Quotient = result;
					respond.Remainder = result1;

				}
				catch (Exception e)
				{
					log.Error(HttpStatusCode.InternalServerError);
					log.Error("Error in the controller div " + e);
					throw new Exception();
				}
			}
			return respond;

		}
		[HttpPost]
		[ActionName("square")]
		public SquareRespond SquarePost(SquareRequest values)
		{	
			log.Trace("this is the service -> square");
			var hasTrackingHeader = Request.Headers.Contains("X-Evi-Tracking-Id");
			var id = hasTrackingHeader ? Request.Headers.GetValues("X-Evi-Tracking-Id").FirstOrDefault() : "";
			SquareRespond respond = new SquareRespond();
			if (values == null)
			{
				log.Error(HttpStatusCode.BadRequest);
				throw new ArgumentNullException();
			}
			else
			{
				try
				{
					respond.Square = (int)(Math.Sqrt(values.Number));
					if (id != null || id == "")
					{
						if (!journals.ContainsKey(id))
						{
							List<Operatione> Ops = new List<Operatione>();
							Operatione op = new Operatione();
							op.Operation = "square";
							op.Calculation = "square: " + values.Number + " = " + respond.Square;
							op.Date = DateTime.Now.ToString("u");
							Ops.Add(op);
							journals[id] = Ops;

						}
						else
						{
							var Ops = journals[id];
							Operatione op = new Operatione();
							op.Operation = "square";
							op.Calculation = "square: " + values.Number + " = " + respond.Square;
							op.Date = DateTime.Now.ToString("u");
							Ops.Add(op);
							journals[id] = Ops;
						}
					}
				}
				catch (Exception e)
				{
					log.Error(HttpStatusCode.InternalServerError);
					log.Error("Error in the controller square " + e);
					throw new Exception();
				}
			}
			return respond;

		}

		[HttpPost]
		[ActionName("query")]
		public QueryRespond QueryPost(QueryRequest values) {
			QueryRespond respond = new QueryRespond();
			if(journals.ContainsKey(values.Id)) {
				respond.Operations = journals[values.Id];
			}
			return respond;
		}

	}
}

