namespace TA_FinalTask;

using NLog;

public class TestLogger
{
    private static readonly Logger logger = LogManager.GetCurrentClassLogger();
    public static void LOG(string message)
    {
        logger.Info(message);
    }
}