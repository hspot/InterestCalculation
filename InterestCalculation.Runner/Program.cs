using System;
using System.Collections.Generic;
using System.Linq;
using InterestCalculation.Entities;
using InterestCalculation.Entities.CreditCard;
using InterestCalculation.Logic;

namespace HNCreditInterestCalculator
{
	class Program
	{		
		static void Main(string[] args)
		{
			ICreditCardInterestLogic interestLogic = new CreditCardInterestLogic();

			var cardHolder1 = new CreditCardHolder
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

			interestLogic.CalculateInterestForHolder(cardHolder1);

			Console.WriteLine("\nTEST CASE 1");
			var cards = cardHolder1.Wallets.First().CreditCards.ToList();
			cards.ForEach(c => Console.WriteLine($"Interest for {c.Type} card: {c.SimpleInterest}"));
			Console.WriteLine($"Total interest for card holder: {cardHolder1.TotalInterest}");

			var cardHolder2 = new CreditCardHolder
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

			interestLogic.CalculateInterestForHolder(cardHolder2);			
			Console.WriteLine("\nTEST CASE 2");
			var case2Wallets = cardHolder2.Wallets.ToList();
			case2Wallets.ForEach(w => Console.WriteLine($"Interest for wallet: {w.TotalInterest}"));			
			Console.WriteLine($"Total interest for card holder: {cardHolder2.TotalInterest}");

			var cardHolderGroups3 = new List<CreditCardHolder>
			{
				new CreditCardHolder
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
				new CreditCardHolder
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
				}
			};

			Console.WriteLine("\nTEST CASE 3");
			for (int i = 0; i < cardHolderGroups3.Count; i++)
			{
				interestLogic.CalculateInterestForHolder(cardHolderGroups3[i]);
				
				var case3Wallets = cardHolderGroups3[i].Wallets.ToList();
				case3Wallets.ForEach(w => Console.WriteLine($"Interest for card holder {i + 1} wallet: {w.TotalInterest}"));
				Console.WriteLine($"Total interest for card holder {i + 1}: {cardHolderGroups3[i].TotalInterest}\n");
			}			
		}
	}
}
