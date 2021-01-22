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
				if(string.IsNullOrWhiteSpace(Search))
				
			{
			
			  stud = _db.EnrollStuds.Where(x => x.Firstname.ToLower().Contains(Name.ToLower()) || x.LastName.ToLower().Contains(Name.ToLower()))
				.OrderBy(o => o.Firstname).ToList();
			}
			
				
				stud = stud.Where(x => x.Firstname.ToLower().Contains(Name.ToLower()) || x.LastName.ToLower().Contains(Name.ToLower()))
				.OrderBy(o => o.Firstname).ToList();
			}
			
		
	    		return Ok(stud);
		}
		
		
		
		
		
		[HttpPost]
		public IHttpActionResult Create(EnrollStud NewStudent)
		{
			
			
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
		
		
		
		
		
		
		[HttpPut]
		public IHttpActionResult Update(EnrollStud updatedstud)
		{
			var stud = _db.EnrollStuds.Find(updatedstud.Id);
			
			if(stud !=null)
			{
				stud.Firstname = updatedstud.Firstname;
				stud.LastName = updatedstud.LastName;
				stud.MiddleName = updatedstud.MiddleName;
				stud.Birthdate = updatedstud.Birthdate;
				stud.Gender = updatedstud.Gender;
				stud.Address = updatedstud.Address;
				stud.GradeLevel = updatedstud.GradeLevel;
				stud.DateofEnroll = updatedstud.DateofEnroll;
				stud.FathersName = updatedstud.FathersName;
				stud.Foccupation = updatedstud.Foccupation;
				stud.MothersName = updatedstud.MothersName;
				stud.Moccupation = updatedstud.Moccupation;
				stud.GuardiansName = updatedstud.GuardiansName;
				stud.LastSchoolattended = updatedstud.LastSchoolattended;
				stud.SchoolId = updatedstud.SchoolId;
				stud.ContactNumberStud = updatedstud.ContactNumberStud;
				stud.ContactNumber = updatedstud.ContactNumber;
				
				
			
			_db.Entry(stud).State = System.Data.Entity.EntityState.Modified;
			_db.SaveChanges();
			return Ok(stud);
			}
			else
				return BadRequest("Song not found!");
		}
		
		
		
		
	}
}