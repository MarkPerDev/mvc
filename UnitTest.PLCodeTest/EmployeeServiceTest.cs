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


		[TestMethod]
		public void CreateAnEmployee_Test()
		{
			var fNameGuid = Guid.NewGuid().ToString();
			var newEmp = new Employee()
			{
				FirstName = fNameGuid,
				LastName = "Test",
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
				Assert.AreEqual(fNameGuid, result.FirstName);
				Assert.IsTrue(result.PayPeriodDeduction.Value > 0);
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
