using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PLCodeTest.Data;

namespace PLCodeTest.Service.Interfaces
{
	interface IBaseServices
	{
		HREntities DBContext { get; set; }
	}
}
