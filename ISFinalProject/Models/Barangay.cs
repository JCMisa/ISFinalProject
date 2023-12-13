using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ISFinalProject.Models
{
	public class Barangay
	{
		public int Id { get; set; }
		//civilian info
		[Required]
		public string FirstName { get; set; }
		[Required]
		public string LastName { get; set; }
		public int Age { get; set; }
		[Required]
		public string Gender { get; set; }
		[Required]
		public string CivilStatus { get; set; }
		public int HouseNo { get; set; }
		[Required]
		public string Occupation { get; set; }
		public double annualIncome { get; set; }

		//contacts
		[Required]
		public string ContactNo { get; set; }
		public string Gmail { get; set; }
	}
}
