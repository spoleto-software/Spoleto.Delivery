using Microsoft.Extensions.Logging.Configuration;
using Microsoft.Extensions.Logging.EventLog;
using NLog;
using NLog.Extensions.Logging;
using Spoleto.Delivery.Callback.Common.Services;
using Spoleto.Delivery.Callback.MasterPost;
using Spoleto.Delivery.Callback.MasterPost.Models;
using Spoleto.Delivery.Extensions;
using Spoleto.Delivery.Extensions.MasterPost;
using Spoleto.Delivery.Providers.MasterPost;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddWindowsService(options =>
{
    options.ServiceName = "Spoleto MasterPost Callback Service";
});

LoggerProviderOptions.RegisterProviderOptions<EventLogSettings, EventLogLoggerProvider>(builder.Services);

// Register NLog:
builder.Services.AddLogging(loggingBuilder =>
{
    // configure Logging with NLog
    //loggingBuilder.ClearProviders();
    loggingBuilder.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
    loggingBuilder.AddNLog();

    InitNLog();
});

builder.Services.AddTransient<IRepository, FakeRepository>();

builder.Services.Configure<MasterPostCallbackOptions>(builder.Configuration.GetSection(nameof(MasterPostCallbackOptions)));

var masterPostOptions = builder.Configuration.GetSection(nameof(MasterPostOptions)).Get<MasterPostOptions>()!;
builder.Services.AddDelivery(MasterPostProvider.ProviderName)
    .AddMasterPost(masterPostOptions.IndividualClientNumber, masterPostOptions.AuthCredentials.ApiKey, masterPostOptions.ServiceUrl);

builder.Services.AddHostedService<Worker>();

var host = builder.Build();
host.Run();

static void InitNLog()
{
    if (System.Diagnostics.Debugger.IsAttached
        && System.IO.File.Exists("nlog.Development.config"))
    {
        NLog.LogManager.Setup().LoadConfigurationFromFile("nlog.Development.config");
    }
    else
    {
        NLog.LogManager.Setup().LoadConfigurationFromFile("NLog.config");
    }
}