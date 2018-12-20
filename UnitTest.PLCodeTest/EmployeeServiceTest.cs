using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PLCodeTest.Service;
using PLCodeTest.Data.Views;
using PLCodeTest.Data;
using Employee = PLCodeTest.Data.Views.Employee;

namespace UnitTest.PLCodeTest
{
	[TestClass]
	public class EmployeeServiceTest
	{

		int? _empId = null;

		[TestInitialize]
		public void MyTestInitialize()
		{
			// Not implemented yet
		}

		[TestCleanup]
		public void MyTestCleanup()
		{
			CleanUpTestData();
		}

		[TestMethod]
		public void GetAllEmployees_Test()
		{
			using (var svc = new EmployeeService())
			{
				var results = svc.GetAllEmployees();

				Assert.IsNotNull(results);
			}
		}

		// Confirms that an employee was created
		// and no discounts were applied
		[TestMethod]
		public void CreateAnEmployeeNoDiscounts_Test()
		{
			var lastNameGuid = Guid.NewGuid().ToString();
			var newEmp = new Employee()
			{
				FirstName = "Steve",
				LastName = lastNameGuid,
				BenefitCostPerYear = 1000m,
				SSN = @"222-33-4444",
				DOB = DateTime.Now
			};

			using (var svc = new EmployeeService())
			{
				_empId = svc.SaveEmployee(newEmp);
				Assert.IsNotNull(_empId);

				var result = svc.GetEmployee(_empId.Value);
				Assert.IsNotNull(result);
				Assert.AreEqual(lastNameGuid, result.LastName);
				Assert.IsTrue(result.PayPeriodDeduction.Value > 0);
				// Assert no discounts were applied
				Assert.IsFalse(result.GetsDiscount);
				Assert.AreEqual(1000, result.TotalBenefitCostPerYear.Value);
				decimal deduction = Math.Round(result.TotalBenefitCostPerYear.Value / 26m, 2);
				Assert.AreEqual(deduction, result.PayPeriodDeduction.Value);
			}
		}

		// Confirms that an employee was created
		// and a 10% discount was applied based on the name starting
		// with 'A'
		[TestMethod]
		public void CreateAnEmployeeWithDiscount_Test()
		{
			var lastNameGuid = Guid.NewGuid().ToString();
			var newEmp = new Employee()
			{
				FirstName = "Adam",
				LastName = lastNameGuid,
				BenefitCostPerYear = 1000m,
				SSN = @"222-33-4444",
				DOB = DateTime.Now
			};

			using (var svc = new EmployeeService())
			{
				_empId = svc.SaveEmployee(newEmp);
				Assert.IsNotNull(_empId);

				var result = svc.GetEmployee(_empId.Value);
				Assert.IsNotNull(result);
				Assert.AreEqual(lastNameGuid, result.LastName);
				Assert.IsTrue(result.PayPeriodDeduction.Value > 0);

				decimal costPerYear = 1000m - (1000m * .1m);
				// Assert a discounts was applied
				Assert.IsTrue(result.GetsDiscount);
				Assert.AreEqual(costPerYear, result.TotalBenefitCostPerYear.Value);
				decimal deduction = Math.Round(result.TotalBenefitCostPerYear.Value / 26m, 2);
				Assert.AreEqual(deduction, result.PayPeriodDeduction.Value);
			}
		}

		#region Private Methods
		private void CleanUpTestData()
		{
			using (var context = new HREntities())
			{
				context.Database.ExecuteSqlCommand(@"delete from employee where Id = {0}", _empId);
			}
		}

		#endregion
	
}
}
