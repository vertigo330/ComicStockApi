using Newtonsoft.Json;

namespace ComicStock.API.Areas.Grades.Models
{
	public class Grade
	{
		[JsonProperty("id")]
		public int Id{ get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }
	}
}