using ComicStock.API.Areas.Suppliers.Model;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ComicStock.API.Areas.Suppliers.Controllers
{
	public class SupplierController : ApiController
	{
		[HttpGet]
		public IEnumerable<Supplier> Get()
		{
			return DataCache.GetSuppliers();
		}

		[HttpPost]
		public HttpResponseMessage Post([FromBody] Supplier supplier)
		{
			var allSuppliers = DataCache.GetSuppliers();
			var existingSupplier = allSuppliers.SingleOrDefault(x => x.Name == supplier.Name);

			if (existingSupplier == null)
			{
				supplier.Id = allSuppliers.Max(x => x.Id) + 1;
				allSuppliers.Add(supplier);
				
				return Request.CreateResponse(HttpStatusCode.OK, supplier);
			}
			return new HttpResponseMessage(HttpStatusCode.Conflict);
		}

		[HttpGet]
		public HttpResponseMessage Get(int id)
		{
			var allSuppliers = DataCache.GetSuppliers();
			var supplier = allSuppliers.SingleOrDefault(x => x.Id == id);

			if (supplier != null)
			{
				return Request.CreateResponse(HttpStatusCode.OK, supplier);
			}
			return new HttpResponseMessage(HttpStatusCode.NotFound);
		}
		
		[HttpPut]
		public HttpResponseMessage Put([FromBody] Supplier supplier)
		{
			var allSuppliers = DataCache.GetSuppliers();
			var supplierToUpdate = allSuppliers.SingleOrDefault(x => x.Id == supplier.Id);

			if (supplierToUpdate != null)
			{
				supplierToUpdate.Name = supplier.Name;
				return new HttpResponseMessage(HttpStatusCode.OK);
			}

			allSuppliers.Add(supplier);
			return new HttpResponseMessage(HttpStatusCode.Created);
		}

		[HttpDelete]
		public HttpResponseMessage Delete(int id)
		{
			var allSuppliers = DataCache.GetSuppliers();
			var supplierToDelete = allSuppliers.SingleOrDefault(x => x.Id == id);

			if (supplierToDelete != null)
			{
				DataCache.Delete(supplierToDelete);
				return new HttpResponseMessage(HttpStatusCode.OK);
			}

			return new HttpResponseMessage(HttpStatusCode.NotFound);
		}

		[HttpPost]
		public IEnumerable<Supplier> Reset()
		{
			DataCache.Initialise();
			return DataCache.GetSuppliers();
		}
	}
}
