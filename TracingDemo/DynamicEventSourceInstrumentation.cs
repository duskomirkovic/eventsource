using System.Diagnostics.Tracing;

public class DynamicEventSourceInstrumentation : IInstrumentation
{
    private static readonly EventSource _source = new EventSource("DM-TracingDemo-Web");

    public void GetSomeDataStart()
    {
        _source.Write("GetSomeDataStart", new EventSourceOptions() { Level = EventLevel.Verbose });
    }

    public void GetSomeDataStop()
    {
        _source.Write("GetSomeDataStop", new EventSourceOptions() { Level = EventLevel.Verbose });
    }

    public void GetSomeMoreDataStart()
    {
        _source.Write("GetSomeMoreDataStart", new EventSourceOptions() { Level = EventLevel.Verbose });
    }

    public void GetSomeMoreDataStop()
    {
        _source.Write("GetSomeMoreDataStop", new EventSourceOptions() { Level = EventLevel.Verbose });
    }

    public void IndexGetStart()
    {
        _source.Write("IndexGetStart", new EventSourceOptions() { Level = EventLevel.Informational });
    }

    public void IndexGetStop()
    {
        _source.Write("IndexGetStop", new EventSourceOptions() { Level = EventLevel.Informational });
    }

    public void SomeIntermediateState(string v1, string v2, string v3)
    {
        _source.Write("SomeIntermediateState", new EventSourceOptions() { Level = EventLevel.Informational }, new { v1, v2, v3 });
    }
}