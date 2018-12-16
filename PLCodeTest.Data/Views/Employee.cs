using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLCodeTest.Data.Views
{
	public class Employee
	{
		public int EmployeeId { get; set; }

		public string FirstName { get; set; }

		public string LastName { get; set; }

		public decimal BenefitCostPerYear { get; set; }

		public decimal SalaryPerYear { get; set; }

		public decimal? Discount { get; set; }

		public DateTime? DOB { get; set; }

		public string SSN { get; set; }

		public IList<Dependent> Dependents { get; set; }
}
}
