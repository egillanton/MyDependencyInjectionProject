namespace MyDependencyInjectionProject.Example2.Interfaces
{
    public interface IBillingProcessor
    {
        void ProcessPayment(string customerName, int price, string product);
    }
}
