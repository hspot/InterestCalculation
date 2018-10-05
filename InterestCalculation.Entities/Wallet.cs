using System.Collections.Generic;
using InterestCalculation.Entities.CreditCard;

namespace InterestCalculation.Entities
{
	/// <summary>
	/// Wallet that contains credit cards
	/// </summary>
	public class Wallet
	{
		/// <summary>
		/// Credit cards in the wallet
		/// </summary>
		public IEnumerable<ICreditCard> CreditCards { get; set; }

		/// <summary>
		/// Total simple interest for all cards in the wallet
		/// </summary>
		public double TotalInterest { get; set; }
	}
}