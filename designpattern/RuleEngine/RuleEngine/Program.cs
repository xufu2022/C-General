// See https://aka.ms/new-console-template for more information

using RuleEngineLib.Discounts;

DiscountCalculator _calculator = new ();
const int DEFAULT_AGE = 30;
var customer = CreateCustomer(65, DateTime.Today.AddDays(-1));

var result = _calculator.CalculateDiscountPercentage(customer);

Customer CreateCustomer(int age = DEFAULT_AGE, DateTime? firstPurchaseDate = null)
{
    return new Customer
    {
        DateOfBirth = DateTime.Today.AddYears(-age).AddDays(-1),
        DateOfFirstPurchase = firstPurchaseDate
    };
}
Console.WriteLine("Hello, World!");
