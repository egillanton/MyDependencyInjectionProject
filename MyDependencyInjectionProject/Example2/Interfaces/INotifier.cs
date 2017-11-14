using MyDependencyInjectionProject.Models;

namespace MyDependencyInjectionProject.Example2.Interfaces
{
    public interface INotifier
    {
        void SendReciept(OrderInfo orderInfo);
    }
}
