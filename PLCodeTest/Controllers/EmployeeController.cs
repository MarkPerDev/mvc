using PLCodeTest.Controllers.Interface;
using PLCodeTest.Data.Views;
using PLCodeTest.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PLCodeTest.Controllers
{
  public class EmployeeController : BaseController
  {
    // GET: Employee
    public ActionResult Index()
    {
        return View();
    }

    // GET: Employee/Details/5
    public ActionResult Details(int? id)
    {
			if (id == null)
			{
				return RedirectToAction("Index", "Home");
			}

			Employee emp = null;
			if (ModelState.IsValid)
			{				
				emp = EmpContext.GetEmployee(id.Value);
			}

			// Go to home page if model is not valid
			return View(emp);
		}

		// GET: Employee/Create
		public ActionResult Create()
    {
        return View();
    }

    // POST: Employee/Create
    [HttpPost]
    public ActionResult Create(Employee employee)
    {
			if (ModelState.IsValid)
			{
				var result = EmpContext.SaveEmployee(employee);
				return RedirectToAction("Details", new { id = result });
			}

			// Go to home page after a post has been created
			return RedirectToAction("Index", "Home");
		}

    // GET: Employee/Edit/5
    public ActionResult Edit(int id)
    {
        return View();
    }

    // POST: Employee/Edit/5
    [HttpPost]
    public ActionResult Edit(int id, FormCollection collection)
    {
      try
    {
        // TODO: Add update logic here
        return RedirectToAction("Index");
      }
      catch
      {
        return View();
      }
    }

    // GET: Employee/Delete/5
    public ActionResult Delete(int id)
    {
			if (ModelState.IsValid)
			{
				EmpContext.DeleteEmployee(id);
			}
			// Go to home page after an employee has been removed
			return RedirectToAction("Index", "Home");
		}

    // POST: Employee/Delete/5
    [HttpPost]
    public ActionResult Delete(int id, FormCollection collection)
    {
      try
      {
        // TODO: Add delete logic here
        return RedirectToAction("Index");
      }
      catch
      {
        return View();
      }
    }
  }
}
