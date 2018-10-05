namespace InterestCalculation.Entities.CreditCard
{
	public interface ICreditCard
	{
		CreditCardType Type { get; }

		double InterestRate { get; set; }

		double Balance { get; set; }

		double SimpleInterest { get; set; }
	}
}
