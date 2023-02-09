public class LoggerInstrumentation : IInstrumentation
{
    private readonly ILogger _logger;

    public LoggerInstrumentation(ILogger<LoggerInstrumentation> logger)
    {
        _logger = logger;
    }

    public void GetSomeDataStart()
    {
        _logger.LogDebug("GetSomeData method on demo service started.");
    }

    public void GetSomeDataStop()
    {
        _logger.LogDebug("GetSomeData method on demo service completed.");
    }

    public void GetSomeMoreDataStart()
    {
        _logger.LogTrace("GetSomeMoreData method on demo service started.");
    }

    public void GetSomeMoreDataStop()
    {
        _logger.LogTrace("GetSomeMoreData method on demo service completed.");
    }

    public void IndexGetStart()
    {
        _logger.LogInformation("Get method on Index page model started.");
    }

    public void IndexGetStop()
    {
        _logger.LogInformation("Get method on Index page model completed.");
    }

    public void SomeIntermediateState(string v1, string v2, string v3)
    {
        _logger.LogInformation("Logging intermediate state. {v1}, {v2}, {v3}.", v1, v2, v3);
    }
}