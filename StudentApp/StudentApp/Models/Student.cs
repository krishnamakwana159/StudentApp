using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentApp.Models
{
    public class Student
    {
		[Key]
		public int StudentId { get; set; }
		[Required]
		public string Name { get; set; }
		[Required]
		public string Address { get; set; }
		[Required]
		public string EmailId { get; set; }
		[Required]
		[Phone]
		public int MobileNo { get; set; }
		[Required]
		public int CourseId { get; set; }

		[Required]
		public int FeeStatus { get; set; }
	}
}
