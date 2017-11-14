using System;
using MyDependencyInjectionProject.Example3.Interfaces;

namespace MyDependencyInjectionProject.Example3
{
    // Has the responsibility to bill a customer
    public class BillingProcessor : IBillingProcessor
    {
        public void ProcessPayment(string customerName, int price, string product)
        {
            Console.WriteLine($"{customerName} has been billed {price} for buying {product}.");
        }
    }
}
