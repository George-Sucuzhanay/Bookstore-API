using System;
namespace BookstoreAPI.Models
{
	public class Book
	{
		public int BookId { get; set; }
		public string ? Title { get; set; }
		public string ? Author { get; set; }
		public int Price { get; set; }
		public int Quantity { get; set; }

	}
}

