using System;
using MyDependencyInjectionProject.Example3.Interfaces;

namespace MyDependencyInjectionProject.Example3
{
    public class ProductRepository : IProductRepository
    {
        public void Save()
        {
            Console.WriteLine("Product Database has been updated");
        }
    }
}
