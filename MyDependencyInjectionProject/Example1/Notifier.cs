using System;
using MyDependencyInjectionProject.Models;

namespace MyDependencyInjectionProject.Example1
{
    // Has the responsibility to send out reciepts
    public class Notifier
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
