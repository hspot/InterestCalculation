namespace InterestCalculation.Entities.CreditCard
{
	/// <summary>
	/// Credit card
	/// </summary>
	public abstract class CreditCard : ICreditCard
	{
		/// <summary>
		/// The type of card: Visa, MasterCard...
		/// </summary>
		public abstract CreditCardType Type { get; }

		//public abstract double InterestRate { get; set; }
		
		/// <summary>
		/// Interest rate
		/// </summary>
		public double InterestRate { get; set; }

		/// <summary>
		/// Balance carrying on the card
		/// </summary>
		public double Balance { get; set; }

		/// <summary>
		/// Interest accrued (usually balance
		/// </summary>
		public double SimpleInterest { get; set; }
	}
}