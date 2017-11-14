using System;
using MyDependencyInjectionProject.Example2.Interfaces;

namespace MyDependencyInjectionProject.Example2
{
    public class CustomerRepository : ICustomerRepository
    {
        public void Save()
        {
            Console.WriteLine("Customer Repository has been updated");
        }
    }
}
