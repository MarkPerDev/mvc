using PLCodeTest.Service;
using PLCodeTest.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PLCodeTest.Controllers
{
	public class BaseController : Controller
	{

		private IEmployeeService _empContext = null;

		public IEmployeeService EmpContext
		{
			get
			{
				if (_empContext == null)
				{
					_empContext = new EmployeeService();
				}
				return _empContext;
			}
		}
	}
}