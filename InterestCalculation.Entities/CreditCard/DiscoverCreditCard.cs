namespace InterestCalculation.Entities.CreditCard
{
	/// <summary>
	/// Discover credit card
	/// </summary>
	public class DiscoverCreditCard : CreditCard
	{
		/// <summary>
		/// The type of credit card.
		/// </summary>
		public override CreditCardType Type
		{
			get { return CreditCardType.Discover; }
		}

		//public override double InterestRate { get; set; } = .01;
	}
}