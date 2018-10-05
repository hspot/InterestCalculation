using Xunit;
using System.Collections.Generic;
using InterestCalculation.Entities;
using InterestCalculation.Entities.CreditCard;
using InterestCalculation.Logic;
using System.Linq;
using Moq;

namespace InterestCalculation.UnitTests
{
	/// <summary>
	/// Unit tests for CreditCardInterestLogic as described in XXX Coding Challenge.docx
	/// WARNING: Description for the test cases are not 100% clear. These unit tests show my understanding of the test cases. 
	/// </summary>
	public class CreditCardInterestLogicTests
	{		
		private CreditCardInterestLogic _logic;
		Mock<IInterestRateProvider> _mockInterestRateProvider;

		public CreditCardInterestLogicTests()
		{
			//Setting shared interest rates. All test cases have the same interest rates
			_mockInterestRateProvider = new Mock<IInterestRateProvider>();		
			var interestRates = new List<KeyValuePair<CreditCardType, double>>
			{
				new KeyValuePair<CreditCardType, double>(CreditCardType.Visa, .10),
				new KeyValuePair<CreditCardType, double>(CreditCardType.MasterCard, .05),
				new KeyValuePair<CreditCardType, double>(CreditCardType.Discover, .01)

			};
			_mockInterestRateProvider.Setup(i => i.GetInterestRates()).Returns(interestRates);

			_logic = new CreditCardInterestLogic(_mockInterestRateProvider.Object);
		}

		/// <summary>
		/// Calculate simple interest for card and holder
		/// </summary>
		[Fact]
		public void CalculateInterest_TestCase1_calculate_simple_interest_for_card_and_holder()
		{
			var cardHolder = new CreditCardHolder
			{
				Wallets = new List<Wallet>
				{
					new Wallet
					{
						CreditCards = new List<CreditCard>
						{
							new VisaCreditCard { Balance = 100 },
							new MasterCardCreditCard { Balance = 100 },
							new DiscoverCreditCard { Balance = 100 }
						}
					}
				}
			};

			_logic.CalculateInterestForHolder(cardHolder);

			var creditCards = cardHolder.Wallets.First().CreditCards.ToList();

			Assert.Equal(10, creditCards[0].SimpleInterest); // per card
			Assert.Equal(5, creditCards[1].SimpleInterest);
			Assert.Equal(1, creditCards[2].SimpleInterest);

			Assert.Equal(16, cardHolder.TotalInterest); // for card holder
		}

		/// <summary>
		/// Calculate simple interest for wallet and holder
		/// </summary>
		[Fact]
		public void CalculateInterest_TestCase2_calculate_simple_interest_for_wallet_and_holder()
		{
			var cardHolder = new CreditCardHolder
			{
				Wallets = new List<Wallet>
				{
					new Wallet
					{
						CreditCards = new List<CreditCard>
						{
							new VisaCreditCard { Balance = 100 },							
							new DiscoverCreditCard { Balance = 100 }
						}
					},
					new Wallet
					{
						CreditCards = new List<CreditCard>
						{							
							new MasterCardCreditCard { Balance = 100 },							
						}
					}
				}
			};

			_logic.CalculateInterestForHolder(cardHolder);

			var wallets = cardHolder.Wallets.ToList();

			Assert.Equal(11, wallets[0].TotalInterest); // per wallet
			Assert.Equal(5, wallets[1].TotalInterest);

			Assert.Equal(16, cardHolder.TotalInterest); // for card holder
		}

		/// <summary>
		/// Calculate simple interest for wallet and holder for 2 card holders
		/// </summary>
		/// <param name="cardHolder">The card holder</param>
		/// <param name="walletInterest">Simple interest for the wallet</param>
		/// <param name="cardHolderInterest">Total simple interest for the card holder</param>
		[Theory]
		[ClassData(typeof(CalculationTestData))]
		public void CalculateInterest_TestCase3_calculate_simple_interest_for_wallet_and_holder_for_2_card_holders(
			CreditCardHolder cardHolder, double walletInterest, double cardHolderInterest)
		{			
			_logic.CalculateInterestForHolder(cardHolder);			
			
			Assert.Equal(walletInterest, cardHolder.Wallets.First().TotalInterest);
			Assert.Equal(cardHolderInterest, cardHolder.TotalInterest);
		}

		private class CalculationTestData : TheoryData<CreditCardHolder, int, int>
		{
			public CalculationTestData()
			{					
				Add(new CreditCardHolder
					{
						Wallets = new List<Wallet>
						{
							new Wallet
							{
								CreditCards = new List<CreditCard>
								{
									new MasterCardCreditCard { Balance = 100 },
									new VisaCreditCard { Balance = 100 }
								}
							}
						}
					}, 
					15, 
					15
				);

				Add(new CreditCardHolder
					{
						Wallets = new List<Wallet>
						{
							new Wallet
							{
								CreditCards = new List<CreditCard>
								{
									new VisaCreditCard { Balance = 100 },
									new MasterCardCreditCard { Balance = 100 },
								}
							}
						}
					},
					15, 
					15
				);		
			}
		}

	}
}
