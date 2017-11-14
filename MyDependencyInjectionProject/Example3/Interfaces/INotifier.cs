using MyDependencyInjectionProject.Models;

namespace MyDependencyInjectionProject.Example3.Interfaces
{
    public interface INotifier
    {
        void SendReciept(OrderInfo orderInfo);
    }
}
