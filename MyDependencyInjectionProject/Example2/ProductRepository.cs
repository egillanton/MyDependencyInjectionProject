using System;
using MyDependencyInjectionProject.Example2.Interfaces;

namespace MyDependencyInjectionProject.Example2
{
    public class ProductRepository : IProductRepository
    {
        public void Save()
        {
            Console.WriteLine("Product Database has been updated");
        }
    }
}
