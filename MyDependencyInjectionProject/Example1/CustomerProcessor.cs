using System;

namespace MyDependencyInjectionProject.Example1
{
    // Has the responsibility to update the database
    public class CustomerProcessor
    {
        public void UpdateCustomerOrder(string orderInfoCustomerName, string orderInfoProduct)
        {
            // Main Problem is here, when you are instanciating these classes
            // Problem when Testing, Unit Test will hit the real database

            CustomerRepository customerRepository = new CustomerRepository();
            ProductRepository productRepository = new ProductRepository();

            customerRepository.Save();
            productRepository.Save();

            Console.WriteLine($"Customer record for {orderInfoCustomerName} updated with purchase of a {orderInfoProduct}");
        }
    }
}
