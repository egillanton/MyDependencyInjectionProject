using MyDependencyInjectionProject.Models;

namespace MyDependencyInjectionProject.Example1
{
    /// <summary>
    /// Has the responsibility to process an order
    /// </summary>
    public class Commerce
    {
        public void Process(OrderInfo orderInfo)
        {
            // Main Problem is here, when you are instanciating these classes
            // Problem when Testing, Unit Test will hit the real database and other services
            // You are being locked into these processor, except you change the coded
            BillingProcessor billingProcessor = new BillingProcessor();
            CustomerProcessor customerProcessor = new CustomerProcessor();
            Notifier notifier = new Notifier();

            billingProcessor.ProcessPayment(orderInfo.CustomerName, orderInfo.Price, orderInfo.Product);
            customerProcessor.UpdateCustomerOrder(orderInfo.CustomerName, orderInfo.Product);
            notifier.SendReciept(orderInfo);
        }
    }
}
