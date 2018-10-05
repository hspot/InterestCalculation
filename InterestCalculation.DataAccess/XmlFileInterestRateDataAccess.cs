using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using InterestCalculation.Entities.CreditCard;

namespace InterestCalculation.DataAccess
{
	/// <summary>
	/// Data access for getting interest rates from a XML files
	/// </summary>
	public class XmlFileInterestRateDataAccess : IXmlFileInterestRateDataAccess
	{
		/// <summary>
		/// Get interest rates for credit cards
		/// </summary>
		/// <returns>Interest rate for each credit card type</returns>
		public IEnumerable<KeyValuePair<CreditCardType, double>> GetInterestRates()
		{
			string textXML = File.ReadAllText("InterestRates.xml");
			XDocument ratesDoc = XDocument.Parse(textXML);
			List<KeyValuePair<CreditCardType, double>> rates = ratesDoc.Root
				 .Elements("Card")
				 .Select(x => GetCard(x))
				 .ToList();			

			return rates;
		}

		private KeyValuePair<CreditCardType, double> GetCard(XElement x)
		{
			var key = x.Elements("Type").First().Value;
			var value = x.Elements("Interest").First().Value;
			return new KeyValuePair<CreditCardType, double>(Enum.Parse<CreditCardType>(key), double.Parse(value));
		}
	}
}
