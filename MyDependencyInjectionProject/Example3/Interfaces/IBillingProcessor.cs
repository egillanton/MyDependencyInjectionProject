namespace MyDependencyInjectionProject.Example3.Interfaces
{
    public interface IBillingProcessor
    {
        void ProcessPayment(string customerName, int price, string product);
    }
}
