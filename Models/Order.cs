using System;
namespace BookstoreAPI.Models
{
	public class Order
	{
		public int OrderId { get; set; }
		public string ? CustomerName { get; set; }
		public int TotalAmount { get; set; }
		public DateOnly ? OrderDate { get; set; }
		public Book ? Book { get; set; }
	}
}

