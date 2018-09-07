using ComicStock.API.Areas.Grades.Models;
using ComicStock.API.Areas.Suppliers.Model;
using System;
using System.Collections.Generic;
using System.Runtime.Caching;

namespace ComicStock.API
{
	public static class DataCache
	{
		const string SUPPLIERS_KEY = "suppliers";

		const string GRADES_KEY = "grades";

		public static void Initialise()
		{
			InitialiseSuppliers();
			InitialiseGrades();
		}

		public static void InitialiseSuppliers()
		{
			var initData = new List<Supplier>
			{
				new Supplier {Id = 11, Name = "Phantomania"},
				new Supplier {Id = 12, Name = "CNA"},
				new Supplier {Id = 13, Name = "ComicCon"},
				new Supplier {Id = 14, Name = "Pick n Pay"},
				new Supplier {Id = 15, Name = "Great Ape"},
				new Supplier {Id = 16, Name = "The Warehouse"},
				new Supplier {Id = 17, Name = "Takealot"}
			};

			var cache = MemoryCache.Default;

			if (cache.Contains(SUPPLIERS_KEY))
			{
				cache.Remove(SUPPLIERS_KEY);
			}

			cache.Add(SUPPLIERS_KEY, initData, DateTimeOffset.UtcNow.AddDays(1));
		}

		public static void InitialiseGrades()
		{
			var initData = new List<Grade>
			{
				new Grade {Id = 1, Name = "Very Fine Indeed!"},
				new Grade {Id = 2, Name = "Fine"},
				new Grade {Id = 3, Name = "Good"},
				new Grade {Id = 4, Name = "Poor"}
			};

			var cache = MemoryCache.Default;

			if (cache.Contains(GRADES_KEY))
			{
				cache.Remove(GRADES_KEY);
			}

			cache.Add(GRADES_KEY, initData, DateTimeOffset.UtcNow.AddDays(1));
		}

		public static List<Supplier> GetSuppliers()
		{
			var cache = MemoryCache.Default;

			if (cache.Contains(SUPPLIERS_KEY))
			{
				return cache.Get(SUPPLIERS_KEY) as List<Supplier>;
			}

			return null;
		}

		public static List<Grade> GetGrades()
		{
			var cache = MemoryCache.Default;

			if (cache.Contains(GRADES_KEY))
			{
				return cache.Get(GRADES_KEY) as List<Grade>;
			}

			return null;
		}

		public static void Add(Supplier supplier)
		{
			var cache = MemoryCache.Default;
			var suppliers = cache.Get(SUPPLIERS_KEY) as List<Supplier>;

			suppliers.Add(supplier);
		}

		public static void Delete(Supplier supplier)
		{
			var cache = MemoryCache.Default;
			var suppliers = cache.Get(SUPPLIERS_KEY) as List<Supplier>;

			suppliers.Remove(supplier);
		}
	}
}