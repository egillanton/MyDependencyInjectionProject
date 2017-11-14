using System;
using MyDependencyInjectionProject.Example3.Interfaces;

namespace MyDependencyInjectionProject.Example3
{
    public class CustomerRepository : ICustomerRepository
    {
        public void Save()
        {
            Console.WriteLine("Customer Repository has been updated");
        }
    }
}
