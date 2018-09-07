using System;
using Newtonsoft.Json;

namespace ComicStock.API.Areas.Suppliers.Model
{
	public class Supplier
	{
		[JsonProperty("id")]
		public int Id { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }
	}
}