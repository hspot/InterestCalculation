### InterestCalculation
Credit card interest calculation by Howard Nguyen

**Framework**: .NET Core 2.1

**HOW TO BUILD**:
From solution root path, run command: dotnet build

**HOW TO RUN UNIT TESTS**:
From solution root path, run command: dotnet test InterestCalculation.UnitTests

**HOW TO RUN CONSOLE/SHELL TESTER**:
From solution root path, run commands:
1. cd InterestCalculation.Runner/bin/Debug/netcoreapp2.1
2. dotnet InterestCalculation.Runner.dll

**FILES OF INTEREST**
1. InterestCalculation.UnitTests.CreditCardInterestLogicTests.cs
      Unit tests to show simple interest calculations using xUnit and Moq.

2. InterestCalculation.DataAccess.IXmlFileInterestRateDataAccess.cs

      Data access interface to provide dependency injection.

3. InterestCalculation.Logic: InterestRateProvider.cs and IInterestRateProvider.cs

      Abstraction layer between logic and data access layers to provide a basic dependency inversion setup.

4. InterestCalculation.Logic: CreditCardInterestLogic.cs and InterestRateProvider.cs

      Separating the responsibility of calculating simple interest and the responsibility of querying for interest rates of each card type.

5. InterestCalculation.Entities.CreditCard: ICreditCard.cs, CreditCard.cs, DiscoverCreditCard.cs, MasterCardCreditCard.cs, VisaCreditCard: 

      CreditCard instances can be cleanly replaced by instances of the subtypes.
