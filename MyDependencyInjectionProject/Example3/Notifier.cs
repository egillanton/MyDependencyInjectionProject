using System;
using MyDependencyInjectionProject.Example3.Interfaces;
using MyDependencyInjectionProject.Models;

namespace MyDependencyInjectionProject.Example3
{
    // Has the responsibility to send out reciepts
    public class Notifier : INotifier
    {
        public void SendReciept(OrderInfo orderInfo)
        {
            Console.WriteLine("The Following Recipt has been sent:");
            Console.WriteLine($"\t Customer: {orderInfo.CustomerName}");
            Console.WriteLine($"\t Product: {orderInfo.Product}");
            Console.WriteLine($"\t Paid Ammount: {orderInfo.Price}");
        }
    }
}
