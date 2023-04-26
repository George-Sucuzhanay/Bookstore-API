using System;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace BookstoreAPI.Models
{
	public class Response
	{
		public int StatusCode { get; set; }
		public string ? StatusDescription { get; set; }
		public List<Order> Orders { get; set; } = new List<Order>();
	}
}

