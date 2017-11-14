using System;
using System.Linq;
using System.Reflection;
using Autofac;
using MyDependencyInjectionProject.Example1;
using MyDependencyInjectionProject.Models;

namespace MyDependencyInjectionProject
{
    class Program
    {
        public static IContainer Container;
        static void Main(string[] args)
        {
            Console.WriteLine("Welecome to my dependency injection project.");

            bool exit = false;
            while (!exit)
            {
                Console.WriteLine();
                string banner = new String('/', 100);
                Console.WriteLine(banner);
                Console.WriteLine("1 - Example 1");
                Console.WriteLine("2 - Example 2");
                Console.WriteLine("3 - Example 3");
                Console.WriteLine("0 - Exit");
                Console.WriteLine();
                Console.WriteLine("Select demo:");

                var choice = Console.ReadLine();
                if (choice == "0")
                {
                    exit = true;
                }
                else
                {
                    OrderInfo orderInfo = new OrderInfo()
                    {
                        CustomerName = "Egill Anton Hlöðversson",
                        Email = "egillanton@live.com",
                        Product = "Surface Book Pro",
                        Price = 1400,
                        CreditCardNumber = "1234567890" 
                    };

                    Console.WriteLine();
                    Console.WriteLine("Order Processing:");
                    Console.WriteLine();
                    switch (choice)
                    {
                        case "1":
                            Console.WriteLine("Example 1");
                            Example1(orderInfo);
                            break;
                        case "2":
                            Console.WriteLine("Example 2");
                            Example2(orderInfo);
                            break;
                        case "3":
                            Console.WriteLine("Example 3");
                            Example3(orderInfo);
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// Example 1: Not testable due to lack of isolation, and code is hard to maintain
        /// </summary>
        /// <param name="orderInfo">The order information.</param>
        private static void Example1(OrderInfo orderInfo)
        {
            Commerce commerce = new Commerce();
            commerce.Process(orderInfo);
        }

        /// <summary>
        /// Example 2: Testable, but hard to maintain, especially if the layers get any deeper, 
        /// and if initialized in different locations.
        /// </summary>
        /// <param name="orederInfo">The order information.</param>
        private static void Example2(OrderInfo orderInfo)
        {
            Example2.Commerce commerce = new Example2.Commerce(
                new Example2.BillingProcessor(), 
                new Example2.CustomerProcessor(
                    new Example2.CustomerRepository(), 
                    new Example2.ProductRepository()), 
                new Example2.Notifier());
            commerce.Process(orderInfo);
        }

        /// <summary>
        /// Example 3: Testable and maintainable, with the use of Dependency Injection
        /// Need to done once instead of many places at once; just call Container.Resolve<>()
        /// </summary>
        /// <param name="orderInfo">The order information.</param>
        private static void Example3(OrderInfo orderInfo)
        {
            ContainerBuilder builder = new ContainerBuilder();

            builder.RegisterType<Example3.Commerce>();
            builder.RegisterType<Example3.Notifier>().As<Example3.Interfaces.INotifier>();

            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .Where(t => t.Name.EndsWith("Processor") && t.Namespace.EndsWith("Example3"))
                .As(t => t.GetInterfaces().FirstOrDefault(i => i.Name == "I" + t.Name));

            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .Where(t => t.Name.EndsWith("Repository") && t.Namespace.EndsWith("Example3"))
                .As(t => t.GetInterfaces().FirstOrDefault(i => i.Name == "I" + t.Name));

            Container = builder.Build();

            Example3.Commerce commerce =  Container.Resolve<Example3.Commerce>();

            commerce.Process(orderInfo);
        }
    }
}
