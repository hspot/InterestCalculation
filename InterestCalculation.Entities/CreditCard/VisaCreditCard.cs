namespace InterestCalculation.Entities.CreditCard
{ 
	/// <summary>
	/// Visa credit card
	/// </summary>
	public class VisaCreditCard : CreditCard
	{
		/// <summary>
		/// The type of credit card
		/// </summary>
		public override CreditCardType Type
		{
			get { return CreditCardType.Visa; }
		}

		//public override double InterestRate { get; set; } = .10;
	}
}