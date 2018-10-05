using System.Collections.Generic;
using InterestCalculation.Entities.CreditCard;

namespace InterestCalculation.Logic
{
	/// <summary>
	/// Interface for InterestRateProvider 
	/// </summary>
	public interface IInterestRateProvider
	{
		/// <summary>
		/// Get interest rate for each credit card types
		/// </summary>
		/// <returns>Interest rates for credit card types: expect one entry per type</returns>
		IEnumerable<KeyValuePair<CreditCardType, double>> GetInterestRates();
	}
}