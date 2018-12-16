using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PLCodeTest.Service;

namespace UnitTest.PLCodeTest
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void GetAllEmployees()
		{
			using (var svc = new BenefitsService())
			{
				var results = svc.GetAllEmployees();
			}
		}
	}
}
