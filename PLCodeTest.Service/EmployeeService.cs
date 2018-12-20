using PLCodeTest.Data;
using PLCodeTest.Data.Views;
using System;
using System.Collections.Generic;
using System.Linq;


namespace PLCodeTest.Service
{
	public class EmployeeService : BaseServices
  {
		/// <summary>
		/// Returns all employees
		/// </summary>
		public IList<Data.Views.Employee> GetAllEmployees()
		{
			return DBContext.Employees.Select(x =>
				new Data.Views.Employee()
				{
					EmployeeId = x.Id,
					FirstName = x.FirstName,
					LastName = x.LastName,
					BenefitCostPerYear = x.BenefitCostPerYear,
					TotalBenefitCostPerYear = x.TotalBenefitCostPerYear,
					PayPeriodDeduction = x.TotalPayPeriodDeduction.Value,
					NetPayAfterDeduction = x.NetPayAfterDeduction.Value,
					Dependents = x.Dependents.Select(z => 
						new Data.Views.Dependent()
						{
							Id = z.Emp_Id,
							FirstName = z.FirstName,
							LastName = z.LastName,
							BenefitCostPerYear = z.BenefitCostPerYear,
							GetsDiscount = z.GetsDiscount,
							DOB = z.DOB,
							SSN = z.SSN
						}).ToList(),
					GetsDiscount = x.GetsDiscount,
					DOB = x.DOB.Value,
					SSN = x.SSN
				}).ToList();
		}

		/// <summary>
		/// Allows for the retrieval of an employee based on
		/// parameter <paramref name="id"/>
		/// </summary>
		public Data.Views.Employee GetEmployee(int id)
		{
			var empFromDB = DBContext.Employees.FirstOrDefault(x => x.Id == id);

			var emp = new Data.Views.Employee
			{
				DOB = empFromDB.DOB.Value,
				FirstName = empFromDB.FirstName,
				LastName = empFromDB.LastName,
				SSN = empFromDB.SSN,
				GetsDiscount = empFromDB.GetsDiscount,
				BenefitCostPerYear = empFromDB.BenefitCostPerYear,
				TotalBenefitCostPerYear = empFromDB.TotalBenefitCostPerYear,
				PayPeriodDeduction = empFromDB.TotalPayPeriodDeduction,
				NetPayAfterDeduction = empFromDB.NetPayAfterDeduction
			};

			if (empFromDB.Dependents != null)
			{
				emp.Dependents = new List<Data.Views.Dependent>();

				foreach (var d in empFromDB.Dependents)
				{
					var dep = new Data.Views.Dependent();
					dep.FirstName = d.FirstName;
					dep.LastName = d.LastName;
					dep.DOB = d.DOB;
					dep.SSN = d.SSN;
					dep.GetsDiscount = d.GetsDiscount;
					dep.BenefitCostPerYear = d.BenefitCostPerYear;
					emp.Dependents.Add(dep);
				}
			}

			return emp;
		}


		/// <summary>
		/// Allows a new employee to be created and saved to the database.
		/// Accepts parameter <paramref name="newEmployee"/>
		/// </summary>
		public int SaveEmployee(Data.Views.Employee newEmployee)
		{
			var emp = new Data.Employee
			{
				DOB = newEmployee.DOB.Value,
				FirstName = newEmployee.FirstName,
				LastName = newEmployee.LastName,
				SSN = newEmployee.SSN,
				SalaryPerYear = newEmployee.SalaryPerYear,
				GetsDiscount = newEmployee.FirstName.ToLower().Substring(0, 1) == "a"
			};
			emp.BenefitCostPerYear = (emp.GetsDiscount) ? 1000m - (1000m * .1m) : 1000m;
			emp.TotalBenefitCostPerYear = emp.BenefitCostPerYear;

			if (newEmployee.Dependents != null)
			{
				foreach (var d in newEmployee.Dependents)
				{
					var dep = new Data.Dependent();
					dep.FirstName = d.FirstName;
					dep.LastName = d.LastName;
					dep.DOB = d.DOB.Value;
					dep.SSN = d.SSN;
					dep.Emp_Id = newEmployee.EmployeeId;
					dep.GetsDiscount = d.FirstName.ToLower().Substring(0, 1) == "a";
					dep.BenefitCostPerYear = (dep.GetsDiscount) ? 500m - (500m * .1m) : 500m;
					emp.TotalBenefitCostPerYear += dep.BenefitCostPerYear;
					emp.Dependents.Add(dep);
				}
			}

			emp.TotalPayPeriodDeduction = emp.TotalBenefitCostPerYear / 26m;
			emp.TotalPayPeriodDeduction = Math.Round(emp.TotalPayPeriodDeduction.Value, 2);

			// Add here pay check amount after deduction
			emp.NetPayAfterDeduction = 2000m - emp.TotalPayPeriodDeduction;
			emp.NetPayAfterDeduction = Math.Round(emp.NetPayAfterDeduction.Value, 2);

			DBContext.Employees.Add(emp);
			DBContext.SaveChanges();

			return emp.Id;
		}

		/// <summary>
		/// Allows for the deletion of an employee and 
		/// subsequent dependents via <paramref name="id"/>
		/// </summary>
		public void DeleteEmployee(int id)
		{
			var emp = DBContext.Employees.FirstOrDefault(x => x.Id == id);
			DBContext.Employees.Remove(emp);
			DBContext.SaveChanges();
		}
	}
}
