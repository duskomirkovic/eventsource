internal class DemoService : IDemoService
{
    private readonly IInstrumentation _instrumentation;

    public DemoService(IInstrumentation instrumentation)
    {
        _instrumentation = instrumentation;
    }

    public int GetSomeData()
    {
        try
        {
            _instrumentation.GetSomeDataStart();
            return 7;
        }
        finally
        {
            _instrumentation.GetSomeDataStop();
        }
    }

    public int GetSomeMoreData()
    {
        try
        {
            _instrumentation.GetSomeMoreDataStart();

            _instrumentation.SomeIntermediateState("First part of the state", "Second part of the state", "Third part of the state");

            return 42;
        }
        finally
        {
            _instrumentation.GetSomeMoreDataStop();
        }
    }
}