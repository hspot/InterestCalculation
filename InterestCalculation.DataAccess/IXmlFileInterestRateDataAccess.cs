using System.Collections.Generic;
using InterestCalculation.Entities.CreditCard;

namespace InterestCalculation.DataAccess
{
	/// <summary>
	/// Interface for XmlFileInterestRateDataAccess
	/// </summary>
	public interface IXmlFileInterestRateDataAccess
	{
		/// <summary>
		/// Get interest rates for credit cards
		/// </summary>
		/// <returns>Interest rate for each credit card type</returns>
		IEnumerable<KeyValuePair<CreditCardType, double>> GetInterestRates();
	}
}