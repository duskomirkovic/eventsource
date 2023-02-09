## DEMO Notes

### Demo 1

Here we can see how to record and analyze `LoggingEventSource` events.

1. Edit ConfigurationExtension.cs `AddInstrumentation` method to register `LoggerInstrumentation`
2. Run the TracingDemo `dotnet run --project .\TracingDemo\TracingDemo.csproj`
3. Collect trace with PerfView `PerfView collect webTrace.etl /onlyProviders=*Microsoft-Extensions-Logging::Informational /Merge:false`
4. Refresh the home page of the demo web application
5. In the PerfView collect dialog stop the collection
6. In the PerfView file explorer view open the webTrace.etl file
7. Open the Events category
8. Select `Microsoft-Extensions-Logging/FormattedMessage` event and press Return (or double click on the event)
9. Inspect the events in the event view 

### Demo 2

Here we can see how to record and analyze events from a dynamic EventSource.

1. Edit ConfigurationExtension.cs `AddInstrumentation` method to register `DynamicEventSourceInstrumentation`
2. Run the TracingDemo `dotnet run --project .\TracingDemo\TracingDemo.csproj`
3. Collect trace with PerfView `PerfView collect webTrace.etl /onlyProviders=*DM-TracingDemo-Web::Informational /Merge:false`
4. Refresh the home page of the demo web application
5. In the PerfView collect dialog stop the collection
6. In the PerfView file explorer view open the webTrace.etl file
7. Open the Events category
8. Select `DM-TracingDemo-Web/IndexGetStart/Start` and `DM-TracingDemo-Web/IndexGetStop/Stop` events (use Shift + Click) and press Return
9. Inspect the events in the event view 
10. Note the `DURATION_MSEC` property

### Demo 3

Now, let's see how to record and analyze events from a classic EventSource.

1. Edit ConfigurationExtension.cs `AddInstrumentation` method to register `EventSourceInstrumentation`
2. Run the TracingDemo `dotnet run --project .\TracingDemo\TracingDemo.csproj`
3. Collect trace with PerfView `PerfView collect webTrace.etl /onlyProviders=*DM-TracingDemo-Web2::Informational /Merge:false`
4. Refresh the home page of the demo web application
5. In the PerfView collect dialog stop the collection
6. In the PerfView file explorer view open the webTrace.etl file
7. Open the Events category
8. Select `DM-TracingDemo-Web2/IndexGet/Start` and `DM-TracingDemo-Web2/IndexGet/Stop` events (use Shift + Click) and press Return
9. Inspect the events in the event view 
10. Note the `DURATION_MSEC` property
11. Note the `FormattedMessage` property

### Demo 4

Now, let's see how to record and analyze events from a classic EventSource.

1. Edit DemoEventSource.cs `IndexGetStop` method to pass in wrong event id to `WriteEvent(9)`
2. Run the TracingDemo `dotnet run --project .\TracingDemo\TracingDemo.csproj`
3. Collect trace with PerfView `PerfView collect webTrace.etl /onlyProviders=*DM-TracingDemo-Web2::Informational /Merge:false`
4. Refresh the home page of the demo web application
5. In the PerfView collect dialog stop the collection
6. In the PerfView file explorer view open the webTrace.etl file
7. Open the Events category
8. Note the absence of `DM-TracingDemo-Web2/IndexGet/Stop` event
9. Note the `DM-TracingDemo-Web2/EventSourceMessage` event and select it and press Return (or double click)
10. Note the `message` and `FormattedMessage` properties

### Demo 5

Let's explore other events that we can record.

1. Run the TracingDemo `dotnet run --project .\TracingDemo\TracingDemo.csproj`
2. Collect trace with PerfView `PerfView collect webTrace.etl /onlyProviders=*DM-TracingDemo-Web2::Informational /ClrEvents:Exception,GCAllObjectAllocation /Merge:false`
3. On the home page of the demo web application click on Privacy and then back to Home
4. In the PerfView collect dialog stop the collection
5. In the PerfView file explorer view open the webTrace.etl file
6. Open the Events category
7. Inspect the events from the sources starting with `Microsoft-Windows-DotNETRuntime` (use Filter text box to narrow down the list)

### Demo 6

1. Run the TracingDemo `dotnet run --project .\TracingDemo\TracingDemo.csproj`
2. Collect trace with PerfView `PerfView collect webTrace.etl /providers=*DM-TracingDemo-Web2::Informational /Merge:false`
3. On the home page of the demo web application click on Privacy and then back to Home
4. In the PerfView collect dialog stop the collection
5. In the PerfView file explorer view open the webTrace.etl file
6. Open the Advanced folder, Exceptions Stacks view
7. Select the TracingDemo process (use filter to find it)
8. Inspect the call stack for the exception that we planted in the "Privacy" page
9. Go back to main PerfView window and open CPU Stacks view
10. Inspect the call stacks and info

### Demo 7

1. Run the TracingDemo `dotnet run --project .\TracingDemo\TracingDemo.csproj`
2. Run the TraceSession `dotnet run --project .\TraceSession\TraceSession.csproj`
3. Refresh the home page of the demo web application
4. Inspect the console of the TraceSession app
5. Note the events and the formatted message


### Demo 8

1. Run the TracingDemo `dotnet run --project .\TracingDemo\TracingDemo.csproj`
2. Start the collection with stop triggers defined

    PerfView.exe collect advancedTrace.etl -BufferSizeMB:1024 -CircularMB:1024 -InMemoryCircularBuffer -Zip:false -Merge:false -NoNGenPdbs -NoNGenRundown -MaxCollectSec:2500000 -CollectMultiple:2 "-StopOnException:InvalidOperationException.*Demo exception" "-StopOnEtwEvent:*DM-TracingDemo-Web2/IndexGet/Stop" -providers=*DM-TracingDemo-Web2::Verbose -ThreadTime 

3. Refresh the home page of the demo web application
4. Chane focus to PerfView collect dialog and wait 10 seconds
5. Note the collection stops after 5 seconds and then shortly starts again
6. On the home page of the demo web application click on Privacy and then back to Home
7. Chane focus to PerfView collect dialog and wait 10 seconds
8. Note the collection stops after 5 seconds
9. Inspect the log file and generated trace files

## Other Notes

### Log level mapping

If we use `LoggingEventSource` we need to consider differences in log level definition. Here are a few examples:

- Logger Information -> ETW Informational 
- Logger Debug -> ETW Verbose
- Logger Trace -> No ETW equivalent (will not be logged)


