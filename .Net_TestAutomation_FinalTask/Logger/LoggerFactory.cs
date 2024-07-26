namespace TA_FinalTask;

public class LoggerFactory: ILoggerFactory
{
    public ILogger CreateLogger(ILoggerFactory.LoggerType type = ILoggerFactory.LoggerType.FILE)
    {
        return type switch
        {
            ILoggerFactory.LoggerType.FILE => new FileLogger(),
            ILoggerFactory.LoggerType.CONSOLE => new ConsoleLogger(),
            _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
        };
    }
}