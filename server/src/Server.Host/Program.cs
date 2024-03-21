using System;
using System.Globalization;
using System.IO;
using Extensions.Serilog;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Events;
using Server.Host;

var builder = WebApplication.CreateBuilder(args);
builder
    .Configuration.AddJsonFile(Path.Combine("settings", "appsettings.json"), true, false)
    .AddJsonFile(
        Path.Combine("settings", $"appsettings.{Environment.GetEnvironmentVariable("ENV")}.json"),
        true,
        false
    )
    .AddJsonFile(Path.Combine("settings", "appsettings.test.json"), true, false);
builder.Services.AddSingleton(sp => sp.GetRequiredService<IConfiguration>().Get<Settings>());
builder.WebHost.ConfigureKestrel(serverOptions =>
{
    serverOptions.ListenAnyIP(5000);
});
builder.Services.Configure<RouteOptions>(options =>
{
    options.LowercaseUrls = true;
    options.LowercaseQueryStrings = true;
});
builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    var supportedCultures = new[] { "en", "ru" };
    options
        .SetDefaultCulture(supportedCultures[0])
        .AddSupportedCultures(supportedCultures)
        .AddSupportedUICultures(supportedCultures);
});
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
const string corsPolicyName = "cors";
builder.Services.AddCors(options =>
{
    options.AddPolicy(
        corsPolicyName,
        policy =>
        {
            policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
        }
    );
});
LogBuilder
    .DefaultConfiguration()
    .WriteTo.Async(sink =>
        sink.Console(
            LogEventLevel.Information,
            LogBuilder.OutputTemplate,
            CultureInfo.InvariantCulture
        )
    )
    .CreateLogger()
    .RegisterTo(builder.Services);
builder.Services.Register();

var app = builder.Build();
app.MapControllers();
app.UseRequestLocalization();
app.UseSwagger();
app.UseSwaggerUI();
app.UseCors(corsPolicyName);
app.Services.Setup();

await app.RunAsync();
