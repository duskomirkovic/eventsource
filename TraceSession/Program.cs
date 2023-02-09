using Microsoft.Diagnostics.Tracing;
using Microsoft.Diagnostics.Tracing.Session;

// create a real time user mode session
using (var session = new TraceEventSession("TraceSessionDemo"))
{
    // Set up Ctrl-C to stop the session
    Console.CancelKeyPress += (object? s, ConsoleCancelEventArgs args) => session.Stop();

    session.Source.Dynamic.All += delegate (TraceEvent data)
    {
        Console.WriteLine($"{data.TimeStamp:O} {data.Level} {data.ProcessName}(pid:{data.ProcessID}) {data.ProviderName}/{data.EventName}: {data.FormattedMessage}");
    };

    session.EnableProvider("DM-TracingDemo-Web2");

    session.Source.Process();   // Listen (forever) for events
}