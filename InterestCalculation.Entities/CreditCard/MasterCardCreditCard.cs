namespace InterestCalculation.Entities.CreditCard
{
	/// <summary>
	/// Master Card credit card
	/// </summary>
	public class MasterCardCreditCard : CreditCard
	{
		/// <summary>
		/// The type of credit card.
		/// </summary>
		public override CreditCardType Type
		{
			get { return CreditCardType.MasterCard; }
		}

		//public override double InterestRate { get; set; } = .05;
	}
}