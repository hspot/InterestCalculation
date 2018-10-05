using InterestCalculation.Entities;
using InterestCalculation.Entities.CreditCard;

namespace InterestCalculation.Logic
{
	public interface ICreditCardInterestLogic
	{
		void CalculateInterestForCard(CreditCard card);
		void CalculateInterestForHolder(CreditCardHolder person);
	}
}