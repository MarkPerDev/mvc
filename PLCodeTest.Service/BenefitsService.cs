using PLCodeTest.Data.Views;
using System.Collections.Generic;
using System.Linq;

namespace PLCodeTest.Service
{
	public class BenefitsService : BaseServices
    {
			public IList<Employee> GetAllEmployees()
			{
				return  DBContext.Employees.Select(x =>
					new Employee()
					{
						EmployeeId = x.Id,
						FirstName = x.FirstName,
						LastName = x.LastName,
						BenefitCostPerYear = x.BenefitCostPerYear,
						Dependents = x.Dependents.Select(z => 
							new Dependent()
							{
								Id = z.Emp_Id,
								FirstName = z.FirstName,
								LastName = z.LastName,
								BenefitCostPerYear = z.BenefitCostPerYear,
								DependentRelation = z.DependentRelation.Relation,
								Discount = z.Discount.Value,
								DOB = z.DOB,
								SSN = z.SSN
							}).ToList(),
						Discount = x.Discount.Value,
						DOB = x.DOB.Value,
						SalaryPerYear = x.SalaryPerYear,
						SSN = x.SSN
					}).ToList();
				}
	}
}
