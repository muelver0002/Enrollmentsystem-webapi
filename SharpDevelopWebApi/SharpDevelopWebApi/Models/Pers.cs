
using System;

namespace SharpDevelopWebApi.Models
{

    public class Pers
    {
		public int Id { get; set; }
		public string Firstname { get; set; }
		public string LastName { get; set; }
		public string Gender { get; set; }
		public string CivilStatus { get; set; }
		
		
		public string StudentId { get; set; }
		public string SubjectId { get; set; }
		
		
		public double P1Grade { get; set; }
		public double P2Grade { get; set; }
		public double P3Grade { get; set; }
		
    }
}
