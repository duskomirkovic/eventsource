using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using Microsoft.Extensions.Logging;

[MemoryDiagnoser]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
public class LoggerBenchmark
{
    private readonly IInstrumentation consoleInstrumentation = new LoggerInstrumentation(LoggerFactory.Create(builder => builder.ClearProviders().AddConsole()).CreateLogger<LoggerInstrumentation>());
    private readonly IInstrumentation nLogInstrumentation = new NLogInstrumentation(NLog.Web.NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger());
    private readonly IInstrumentation dynamicEventSourceInstrumentation = new DynamicEventSourceInstrumentation();
    private readonly IInstrumentation eventSourceInstrumentation = new EventSourceInstrumentation();
    private readonly string v1 = "First part of the state";
    private readonly string v2 = "Second part of the state";
    private readonly string v3 = "Third part of the state";
    private int counter = 0;

    [Benchmark]
    public void NLogFile_NoArguments() => nLogInstrumentation.IndexGetStart();

    [Benchmark]
    public void NLogFile_NoArguments_NoLog() => nLogInstrumentation.GetSomeDataStart();

    [Benchmark]
    public void NLogFile_3StringArguments() => nLogInstrumentation.SomeIntermediateState(v1, v2, v3);

    [Benchmark]
    public void ConsoleLogger_NoArguments() => consoleInstrumentation.IndexGetStart();

    [Benchmark]
    public void ConsoleLogger_NoArguments_NoLog() => consoleInstrumentation.GetSomeDataStart();

    [Benchmark]
    public void ConsoleLogger_3StringArguments() => consoleInstrumentation.SomeIntermediateState(v1, v2, v3);

    [Benchmark]
    public void DynamicEventSource_NoArguments() => dynamicEventSourceInstrumentation.IndexGetStart();

    [Benchmark]
    public void DynamicEventSource_NoArguments_NoLog() => dynamicEventSourceInstrumentation.GetSomeDataStart();

    [Benchmark]
    public void DynamicEventSource_3StringArguments() => dynamicEventSourceInstrumentation.SomeIntermediateState(v1, v2, v3);

    [Benchmark]
    public void EventSource_NoArguments() => eventSourceInstrumentation.IndexGetStart();

    [Benchmark]
    public void EventSource_NoArgumentsx10()
    {
        for (int i = 0; i < 10; i++)
        {
            eventSourceInstrumentation.IndexGetStart();
        }
    }


    [Benchmark]
    public void EventSource_NoArguments_NoLog1() => eventSourceInstrumentation.GetSomeDataStart();

    [Benchmark]
    public void EventSource_NoArguments_NoLog2() => eventSourceInstrumentation.GetSomeMoreDataStart();

    [Benchmark]
    public void EventSource_3StringArguments() => eventSourceInstrumentation.SomeIntermediateState(v1, v2, v3);

    [Benchmark]
    public void Interlocked_Increment() => Interlocked.Increment(ref counter);
}