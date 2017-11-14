using System;

namespace MyDependencyInjectionProject.Example1
{
    // Has the responsibility to bill a customer
    public class BillingProcessor
    {
        public void ProcessPayment(string customerName, int price, string product)
        {
            Console.WriteLine($"{customerName} has been billed {price}$ for buying {product}.");
        }
    }
}
