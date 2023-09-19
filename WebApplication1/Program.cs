using LokiLoggingProvider.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Logging.AddLoki(loggerOptions =>
{
    loggerOptions.Client = PushClient.Grpc;
    loggerOptions.StaticLabels.JobName = "LokiWebApplication";
    loggerOptions.Formatter = Formatter.Json;
    loggerOptions.StaticLabels.AdditionalStaticLabels.Add("SystemName", "LokiUsing");
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();
