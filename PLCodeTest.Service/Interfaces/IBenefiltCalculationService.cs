namespace PLCodeTest.Service
{
	public interface IBenefiltCalculationService
	{
		decimal CalculateDiscount(decimal total, decimal percentage);
		
		decimal CalculateDeduction(decimal numerator, decimal denominator);

		decimal CalculateGrossafterDeduction(decimal total, decimal deduction);		
	}
}