using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLCodeTest.Data.Views
{
	public class Employee
	{
		public int EmployeeId { get; set; }

		[Required]
		[StringLength(50, MinimumLength = 2, ErrorMessage = "* First Name is required.")]
		[Display(Name = "First Name")]
		public string FirstName { get; set; }

		[Required]
		[StringLength(50, MinimumLength = 2, ErrorMessage = "* Last Name is required.")]
		[Display(Name = "Last Name")]
		public string LastName { get; set; }

		public decimal? BenefitCostPerYear { get; set; }

		public decimal? TotalBenefitCostPerYear { get; set; }

		public decimal SalaryPerYear
		{ get
			{
				// Based on 26 x 2000
				return 52000m;
			}
		}

		public decimal? PayPeriodDeduction { get; set; }

		public decimal? NetPayAfterDeduction { get; set; }

		public int  NumberOfPayPeriods
		{
			get
			{
				return 26;
			}
		}

		public bool GetsDiscount { get; set; }

		[Required]
		public DateTime? DOB { get; set; }

		[Required]
		public string SSN { get; set; }

		public IList<Dependent> Dependents { get; set; }
}
}
