using MyDependencyInjectionProject.Example2.Interfaces;
using MyDependencyInjectionProject.Models;

namespace MyDependencyInjectionProject.Example2
{
    /// <summary>
    /// Has the responsibility to process an order
    /// </summary>
    public class Commerce
    {
        readonly IBillingProcessor _billingProcessor;
        readonly ICustomerProcessor _customerProcessor;
        readonly INotifier _notifier;

        public Commerce(IBillingProcessor billingProcessor, ICustomerProcessor customerProcessor, INotifier notifier)
        {
            _billingProcessor = billingProcessor;
            _customerProcessor = customerProcessor;
            _notifier = notifier;
        }


        public void Process(OrderInfo orderInfo)
        {
            _billingProcessor.ProcessPayment(orderInfo.CustomerName, orderInfo.Price, orderInfo.Product);
            _customerProcessor.UpdateCustomerOrder(orderInfo.CustomerName, orderInfo.Product);
            _notifier.SendReciept(orderInfo);
        }
    }
}
