public class NaiveConsoleInstrumentation : IInstrumentation
{
    public void GetSomeDataStart()
    {
        Console.WriteLine("GetSomeData method on demo service started.");
    }

    public void GetSomeDataStop()
    {
        Console.WriteLine("GetSomeData method on demo service completed.");
    }

    public void GetSomeMoreDataStart()
    {
        Console.WriteLine("GetSomeMoreData method on demo service started.");
    }

    public void GetSomeMoreDataStop()
    {
        Console.WriteLine("GetSomeMoreData method on demo service completed.");
    }

    public void IndexGetStart()
    {
        Console.WriteLine("Get method on Index page model started.");
    }

    public void IndexGetStop()
    {
        Console.WriteLine("Get method on Index page model completed.");
    }

    public void SomeIntermediateState(string v1, string v2, string v3)
    {
        Console.WriteLine("Logging intermediate state. {0}, {1}, {2}.", v1, v2, v3);
    }
}
