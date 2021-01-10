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
		public IHttpActionResult Index(string Search="", string Name="")
		{
			List<EnrollStud> stud;
			if(string.IsNullOrWhiteSpace(Search))
			{
				
				 stud = _db.EnrollStuds.ToList();
			  
			}
			
			else{
			
				
				
				stud = _db.EnrollStuds.Where(x => x.GradeLevel.Contains(Search)).OrderBy(o => o.GradeLevel).ToList();
			}
			
			if(!string.IsNullOrWhiteSpace(Name))
			{
			
				
				stud = stud.Where(x => x.Firstname.ToLower().Contains(Name.ToLower()) || x.LastName.ToLower().Contains(Name.ToLower()))
				.OrderBy(o => o.Firstname).ToList();
			}
			
		
	    		return Ok(stud);
		}
		
		
		
		
		
		[HttpPost]
		public IHttpActionResult Create(EnrollStud NewStudent)
		{
			
			NewStudent.DateofEnroll = DateTime.Now;
			_db.EnrollStuds.Add(NewStudent);
			_db.SaveChanges();
			return Ok(NewStudent);
		
		}
	
		//Delete Method//
		[Route("api/enrollstud/{id}")]
		[HttpDelete]
		public IHttpActionResult Delete(int Id)
		{
			var stud = _db.EnrollStuds.Find(Id);
			if(stud != null)
			{
				_db.EnrollStuds.Remove(stud);
				_db.SaveChanges();
				return Ok("Succesfully Deleted");
			}
			else
				return BadRequest("Song not found");
		}
		
		
	}
}