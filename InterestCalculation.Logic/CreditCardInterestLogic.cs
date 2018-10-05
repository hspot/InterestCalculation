using InterestCalculation.Entities;
using InterestCalculation.Entities.CreditCard;
using System.Collections.Generic;
using System.Linq;

namespace InterestCalculation.Logic
{
	/// <summary>
	/// Logic to calculate simple interest
	/// </summary>
	public class CreditCardInterestLogic : ICreditCardInterestLogic
	{
		private readonly IInterestRateProvider _interestRateProvider;
		private IEnumerable<KeyValuePair<CreditCardType, double>> _interestRates;

		/// <summary>
		/// Default constructor
		/// </summary>
		public CreditCardInterestLogic() : this(new InterestRateProvider())
		{
		}

		/// <summary>
		/// Constructor with dependency parameters to be used for dependency injection
		/// </summary>
		/// <param name="interestRateProvider">Interest rate provider</param>
		public CreditCardInterestLogic(IInterestRateProvider interestRateProvider)
		{
			_interestRateProvider = interestRateProvider;
			_interestRates = _interestRateProvider.GetInterestRates();
		}

		/// <summary>
		/// Calculate interest for all cards and all wallets of the credit card holder
		/// </summary>
		/// <param name="person">The person to calculate interest for</param>
		public void CalculateInterestForHolder(CreditCardHolder person)
		{
			foreach(Wallet wallet in person.Wallets)
			{
				foreach(CreditCard card in wallet.CreditCards)
				{
					card.InterestRate = _interestRates.First(r => r.Key == card.Type).Value;
					CalculateInterestForCard(card);
					wallet.TotalInterest += card.SimpleInterest;
				}
				person.TotalInterest += wallet.TotalInterest;
			}
		}

		/// <summary>
		/// Calculate interest for a credit card
		/// Resulting interest will be stored in the SimpleInterest property of the card
		/// </summary>
		/// <param name="card">The credit card</param>
		public void CalculateInterestForCard(CreditCard card)
		{
			card.SimpleInterest = card.Balance * card.InterestRate;
		}		
	}
}
