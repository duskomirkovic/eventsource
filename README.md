# Fast and Flexible Tracing/Logging in .NET

This repository contains examples demonstrated during the "Fast and Flexible Tracing/Logging in .NET".

Slides can be downloaded [here](FastFlexibleLoggingTracingdotNET.pdf).

[TracingDemo](TracingDemo) is a web application that will emit some log events. See the [README](TracingDemo/README.md) for demo steps.

[TracingBenchmark](TracingBenchmark) is a benchmark application that will measure the performance of the EventSource comapred to console and NLog logers. To get the relevant measurements, before running the benchmark please start the recording of those events in PerfView (or some other means). PerfView recording can be started with this command:

    perfview collect webTrace.etl /onlyProviders=*DM-TracingDemo-Web::Informational,*DM-TracingDemo-Web2::Informational /InMemoryCircularBuffer

After the benchmark you can cancel the recording.

[TraceSession](TraceSession) is an example of logging application that can subscribe to events from another app. See Demo 7 [here](TracingDemo/README.md).
