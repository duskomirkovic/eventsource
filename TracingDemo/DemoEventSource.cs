using System.Diagnostics.Tracing;

[EventSource(Name = "DM-TracingDemo-Web2")]
internal class DemoEventSource : EventSource
{
    public DemoEventSource()
    {
    }

    [Event(1, Level = EventLevel.Verbose, Message = "GetSomeData method on demo service started.")]
    internal void GetSomeDataStart()
    {
        WriteEvent(1);
    }

    [Event(2, Level = EventLevel.Verbose, Message = "GetSomeData method on demo service completed.")]
    internal void GetSomeDataStop()
    {
        WriteEvent(2);
    }

    [Event(3, Level = EventLevel.Verbose, Message = "GetSomeMoreData method on demo service started.")]
    internal void GetSomeMoreDataStart()
    {
        if (IsEnabled(EventLevel.Verbose, EventKeywords.None))
        {
            WriteEvent(3);
        }
    }

    [Event(4, Level = EventLevel.Verbose, Message = "GetSomeMoreData method on demo service completed.")]
    internal void GetSomeMoreDataStop()
    {
        if (IsEnabled(EventLevel.Verbose, EventKeywords.None))
        {
            WriteEvent(4);
        }
    }

    [Event(5, Level = EventLevel.Informational, Message = "Get method on Index page model started.")]
    internal void IndexGetStart()
    {
        WriteEvent(5);
    }

    [Event(6, Level = EventLevel.Informational, Message = "Get method on Index page model completed.")]
    internal void IndexGetStop()
    {
        WriteEvent(6);
    }

    [Event(7, Level = EventLevel.Informational, Message = "Logging intermediate state. {0}, {1}, {2}.")]
    internal void SomeIntermediateState(string v1, string v2, string v3)
    {
        WriteEvent(7, v1, v2, v3);
    }
}