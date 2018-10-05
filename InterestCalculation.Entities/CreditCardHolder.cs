using System.Collections.Generic;

namespace InterestCalculation.Entities
{
	/// <summary>
	/// The person who owns credit card(s)
	/// </summary>
	public class CreditCardHolder
	{
		/// <summary>
		/// Wallets of the credit card holder
		/// </summary>
		public IEnumerable<Wallet> Wallets { get; set; }

		/// <summary>
		/// Total simple interest for all of card holder's wallets
		/// </summary>
		public double TotalInterest { get; set; }
	}
}