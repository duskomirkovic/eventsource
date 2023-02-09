using NLog;

public class NLogInstrumentation : IInstrumentation
{
    private readonly Logger _logger;

    public NLogInstrumentation(Logger logger)
    {
        _logger = logger;
    }

    public void GetSomeDataStart()
    {
        _logger.Debug("GetSomeData method on demo service started.");
    }

    public void GetSomeDataStop()
    {
        _logger.Debug("GetSomeData method on demo service completed.");
    }

    public void GetSomeMoreDataStart()
    {
        _logger.Trace("GetSomeMoreData method on demo service started.");
    }

    public void GetSomeMoreDataStop()
    {
        _logger.Trace("GetSomeMoreData method on demo service completed.");
    }

    public void IndexGetStart()
    {
        _logger.Info("Get method on Index page model started.");
    }

    public void IndexGetStop()
    {
        _logger.Info("Get method on Index page model completed.");
    }

    public void SomeIntermediateState(string v1, string v2, string v3)
    {
        _logger.Info("Logging intermediate state. {v1}, {v2}, {v3}.", v1, v2, v3);
    }
}