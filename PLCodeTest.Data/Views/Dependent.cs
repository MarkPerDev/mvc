using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLCodeTest.Data.Views
{
	public class Dependent
	{
		public int Id { get; set; }

		[Required]
		public string FirstName { get; set; }

		[Required]
		public string LastName { get; set; }

		public decimal? BenefitCostPerYear { get; set; }

		public bool GetsDiscount { get; set; }

		[Required]
		public DateTime? DOB { get; set; }

		[Required]
		public string SSN { get; set; }

		public string DependentRelation { get; set; }
	}
}
