public class EventSourceInstrumentation : IInstrumentation
{
    private static readonly DemoEventSource _source = new DemoEventSource();

    public void GetSomeDataStart()
    {
        _source.GetSomeDataStart();
    }

    public void GetSomeDataStop()
    {
        _source.GetSomeDataStop();
    }

    public void GetSomeMoreDataStart()
    {
        _source.GetSomeMoreDataStart();
    }

    public void GetSomeMoreDataStop()
    {
        _source.GetSomeMoreDataStop();
    }

    public void IndexGetStart()
    {
        _source.IndexGetStart();
    }

    public void IndexGetStop()
    {
        _source.IndexGetStop();
    }

    public void SomeIntermediateState(string v1, string v2, string v3)
    {
        _source.SomeIntermediateState(v1, v2, v3);
    }
}
