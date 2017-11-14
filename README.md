# My Dependency Injection Project
Simple console application that  demonstrates the use of Dependency Injection.


```csharp
// Not testable due to lack of isolation. and code is hard to maintain
private static void Example1(OrderInfo orderInfo)
{
    Commerce commerce = new Commerce();
    commerce.Process(orderInfo);
}

/// <summary>
/// Stage2: Testable, but hard to maintain, especially if the layers get any deeper, and if initialized in different locations.
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
/// Stage3: Testable and maintainable, with the use of Dependency Injection
/// Need to done once instead of many places at once. Just call Container.Resolve
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

```
