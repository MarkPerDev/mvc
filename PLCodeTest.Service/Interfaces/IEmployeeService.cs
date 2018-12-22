using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLCodeTest.Service.Interfaces
{
	public interface IEmployeeService
	{
		/// <summary>
		/// Returns all employees
		/// </summary>
		IList<Data.Views.Employee> GetAllEmployees();

		/// <summary>
		/// Allows for the retrieval of an employee based on
		/// parameter <paramref name="id"/>
		/// </summary>
		Data.Views.Employee GetEmployee(int id);

		/// <summary>
		/// Allows a new employee to be created and saved to the database.
		/// Accepts parameter <paramref name="newEmployee"/>
		/// </summary>
		int SaveEmployee(Data.Views.Employee newEmployee);

		/// <summary>
		/// Allows for the deletion of an employee and 
		/// subsequent dependents via <paramref name="id"/>
		/// </summary>
		void DeleteEmployee(int id);
	}
}
