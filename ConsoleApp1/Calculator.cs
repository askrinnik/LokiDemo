using Microsoft.Extensions.Logging;

namespace ConsoleApp1;

public class Calculator
{
    private readonly ILogger _logger;
    public Calculator(ILoggerFactory loggerFactory)
    {
        _logger = loggerFactory.CreateLogger<Calculator>();
    }

    public int Sum(int x, int y)
    {
        _logger.LogInformation("Calculating....");
        return x + y;
    }
}