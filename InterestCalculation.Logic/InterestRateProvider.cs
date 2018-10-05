using InterestCalculation.DataAccess;
using InterestCalculation.Entities.CreditCard;
using System.Collections.Generic;

namespace InterestCalculation.Logic
{
	/// <summary>
	/// Provider of interest rates
	/// (Provide abstraction between policy/logic and mechanism/data access layers)
	/// </summary>
	public class InterestRateProvider : IInterestRateProvider
	{
		private readonly IXmlFileInterestRateDataAccess _interestRateDataAccess;

		/// <summary>
		/// Default constructor
		/// </summary>
		public InterestRateProvider() : this(new XmlFileInterestRateDataAccess())
		{}

		/// <summary>
		/// Constructor with dependency parameters to be used for dependency injection
		/// </summary>
		/// <param name="interestRateDataAccess"></param>
		public InterestRateProvider(IXmlFileInterestRateDataAccess interestRateDataAccess)
		{
			_interestRateDataAccess = interestRateDataAccess;
		}

		/// <summary>
		/// Get interest rate for each credit card types
		/// </summary>
		/// <returns>Interest rates for credit card types: expect one entry per type</returns>
		public IEnumerable<KeyValuePair<CreditCardType, double>> GetInterestRates()
		{
			return _interestRateDataAccess.GetInterestRates();
		}
	}
}
