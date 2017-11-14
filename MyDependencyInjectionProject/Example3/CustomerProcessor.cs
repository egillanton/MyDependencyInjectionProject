using System;
using MyDependencyInjectionProject.Example3.Interfaces;

namespace MyDependencyInjectionProject.Example3
{
    // Has the responsibility to update the database
    public class CustomerProcessor : ICustomerProcessor
    {
        readonly ICustomerRepository _customerRepository;
        readonly IProductRepository _productRepository;

        public CustomerProcessor(ICustomerRepository customerRepository, IProductRepository productRepository)
        {
            _customerRepository = customerRepository;
            _productRepository = productRepository;
        }


        public void UpdateCustomerOrder(string customerName, string product)
        {
            _customerRepository.Save();
            _productRepository.Save();

            Console.WriteLine($"Customer record for {customerName} updated with purchase of a {product}");
        }
    }
}
