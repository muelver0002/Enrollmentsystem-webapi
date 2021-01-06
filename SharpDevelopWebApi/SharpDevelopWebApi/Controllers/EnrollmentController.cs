using System.Web;
using SharpDevelopWebApi.Helpers.JWT;
using SharpDevelopWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SharpDevelopWebApi.Controllers
{
	/// <summary>
	/// Description of EnrollmentController.
	/// </summary>
	public class EnrollmentController : ApiController
	{
		SDWebApiDbContext _db = new SDWebApiDbContext();
		
		[HttpGet]
		public IHttpActionResult Index()
		{
			var enroll = _db.EnrollStuds.ToList();		
			return Ok(enroll);
		}
		
		
		
		
		
		[HttpPost]
		public IHttpActionResult Create(EnrollStud NewStudent)
		{
			_db.EnrollStuds.Add(NewStudent);
			_db.SaveChanges();
			return Ok(NewStudent);
		
		}
		
		
		
	}
}