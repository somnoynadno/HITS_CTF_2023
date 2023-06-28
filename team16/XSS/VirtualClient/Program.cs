using Microsoft.Playwright;
using PlaywrightClient.Models;
using PlaywrightClient.Services;
using PlaywrightClient.Utilities;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.BindOptions<VirtualClientOptions>(builder.Configuration.GetRequiredSection("VirtualClient"));
builder.Services.AddOptions<VirtualClientOptions>()
#pragma warning disable CS8601, CS8604
    .Configure(x => x.ConnectionString = builder.Configuration["CLIENT_CONNECTION_STRING"])
    .Configure(x => x.VisitFrequency = int.Parse(builder.Configuration["CLIENT_VISIT_FREQUENCY"]))
    .Configure(x => x.TargetBoardId = builder.Configuration["CLIENT_TARGET_BOARD_ID"])
    .Configure(x => x.Username = builder.Configuration["CLIENT_USERNAME"])
    .Configure(x => x.Password = builder.Configuration["CLIENT_PASSWORD"])
#pragma warning restore CS8601, CS8604
    .ValidateDataAnnotations().ValidateOnStart();

builder.Services.AddScoped<IVirtualClient, VirtualClient>();
builder.Services.AddHostedService<VirtualClientOperator>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
