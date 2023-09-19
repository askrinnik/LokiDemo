using ConsoleApp1;
using LokiLoggingProvider.Options;
using Microsoft.Extensions.Logging;

using var loggerFactory = LoggerFactory.Create(
    builder => builder
        .AddConsole()
        .AddLoki(loggerOptions =>
        {
            loggerOptions.Client = PushClient.Grpc;
            loggerOptions.StaticLabels.JobName = "LokiConsoleApplication";
            loggerOptions.Formatter = Formatter.Json;
            loggerOptions.StaticLabels.AdditionalStaticLabels.Add("SystemName", "LokiUsing");
        }));


var logger = loggerFactory.CreateLogger<Program>();

var a = 2;
var b = 3;
var c = a + b;

logger.LogInformation($"c={c}");

var calculator = new Calculator(loggerFactory);
var d = calculator.Sum(c , 5);

if (d > 6)
    logger.LogWarning("More than 6!");

logger.LogError("Too bad!");

Console.WriteLine(d);

GetWeatherForecast(logger);


Console.ReadLine();
static void GetWeatherForecast(ILogger logger1)
{
    using var client = new HttpClient();
    var response = client.GetStringAsync(new Uri("http://localhost:5151/WeatherForecast")).Result;

    logger1.LogInformation("HTTP response {Response}", response);
}

