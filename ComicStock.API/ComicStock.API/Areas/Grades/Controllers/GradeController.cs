﻿using ComicStock.API.Areas.Grades.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace ComicStock.API.Areas.Grades.Controllers
{
	public class GradeController : ApiController
	{
		[HttpGet]
		[Route("api/grades")]
		public IEnumerable<Grade> Get()
		{
			return DataCache.GetGrades();
		}
	}
}
