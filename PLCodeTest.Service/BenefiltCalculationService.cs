using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PLCodeTest.Service.Interfaces;

namespace PLCodeTest.Service
{
	public class BenefiltCalculationService : BaseServices, IBenefiltCalculationService
	{
		public decimal CalculateDiscount(decimal total, decimal percentage)
		{
			return total - (total * percentage);
		}

		public decimal CalculateDeduction(decimal numerator, decimal denominator)
		{
			return Round(numerator / denominator);
		}

		public decimal CalculateGrossafterDeduction(decimal total, decimal deduction)
		{
			return Round(total - deduction);
		}

		private decimal Round(decimal deduction)
		{
			return Math.Round(deduction, 2);
		}
	}
}
