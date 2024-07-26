namespace TA_FinalTask;

using NLog;

public interface ILogger
{
    void LOG(string message);
}

public class FileLogger : ILogger
{
    private static readonly Logger logger = LogManager.GetCurrentClassLogger();
    public void LOG(string message)
    {
        logger.Info(message);
    }
}

public class ConsoleLogger : ILogger
{
    private static readonly Logger logger = LogManager.GetCurrentClassLogger();
    public void LOG(string message)
    {
        logger.Debug(message);
    }
}