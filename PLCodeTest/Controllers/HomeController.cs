using PLCodeTest.Service;
using System.Web.Mvc;

namespace PLCodeTest.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			using (var context = new EmployeeService())
			{
				return View(context.GetAllEmployees());
			}
		}

		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}
	}
}