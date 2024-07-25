namespace TA_FinalTask;

using NLog;

public interface ITestLogger
{
    void LOG(string message);
}

public class TestLogger : ITestLogger
{
    private static readonly Logger logger = LogManager.GetCurrentClassLogger();
    public void LOG(string message)
    {
        logger.Info(message);
    }
}