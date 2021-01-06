/*
 * Created by SharpDevelop.
 * User: acer
 * Date: 06/01/2021
 * Time: 2:41 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace SharpDevelopWebApi.Models
{
	/// <summary>
	/// Description of EnrollSud.
	/// </summary>
	public class EnrollStud
	{
		
		public int Id {get; set;}
		public string Firstname {get; set;}
		public string LastName {get; set;}
		public string MiddleName {get; set;}
		public DateTime? Birthdate {get; set;}
		public string Gender {get; set;}
		public string Address {get; set;}
		public string GradeLevel {get; set;}
		public DateTime? DateofEnroll{get; set;}
		
		public string FathersName {get; set;}
		public string MothersName {get; set;}
		public string GuardiansName {get; set;}
		
		public string LastSchoolattended {get; set;}
		public string SchoolId {get; set;}
		
		
		
		
		
	}
}
